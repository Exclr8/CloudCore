///ref: <script src="~/Scripts/jquery.signalR-2.1.2.js"></script>
///ref: <script src="~/signalr/hubs"></script>

var dashboardService = function () {
    var maxRetryCount = 10;
    var retryCount;
    var service;
    var slowConnectionEvent;

    var initialise = function (updateKpiCallback, slowConnectionCallback) {
        retryCount = 0;

        service = $.connection.kpiDashboardService;

        slowConnectionEvent = slowConnectionCallback;

        $.connection.hub.connectionSlow(function () {
            connectionSlow();
        });

        $.connection.hub.disconnected(function () {
            connectionDisconected();
        });

        if (typeof (updateKpiCallback) === 'undefined')
            throw 'Mandatory parameter UpdateKpiCallback not supplied.';

        service.client.updateKpi = updateKpiCallback;
    }

    var startConnection = function () {
        $.connection.hub.start()
            .done(function () {
                service.server.registerConnection($.connection.hub.id);
            });
    }

    var connectionDisconected = function () {
        if (retryCount < maxRetryCount) {
            retryCount++;
            setTimeout(function () {
                $.connection.hub.start();
            }, 5000);
        }
    }

    var connectionSlow = function () {
        if (typeof (slowConnectionEvent) !== 'undefined') {
            slowConnectionEvent();
        }
    }

    return {
        StartSignalR: function (updateKpiCallback, optionalSlowConnectionCallback) {
            initialise(updateKpiCallback, optionalSlowConnectionCallback);
            startConnection();
        }
    }
}();

var dashboardCache = function () {
    var self = this;
    var storage = new localStorageCache(window.localStorage);


    self.addItem = function (data) {
        storage.setItem(data.UserId + '_' + data.TilePosition, data);
    }

    self.getItem = function (key) {
        return storage.getItem(key);
    }

    self.removeItem = function (key) {
        storage.removeItem(key);
    }

    return self;
}();

var dashboard = {
    iUserId: 0,
    removeUrlAction: '',
    updateKpi: function (kpiData) {
        dashboard.updateKpiHtml(kpiData);
        dashboardCache.addItem(kpiData);
    },

    updateKpiHtml: function (kpiData) {
        $('#zone_' + kpiData.TilePosition)
            .html('<div class="dashboardRemove" style="display:none;">Remove</div>')
            .removeClass('dashcontainerEmpty')
            .addClass('dashcontainer')
            .css('background-image', 'url(data:image/gif;base64,' + kpiData.Image + ')');

        dashboard.initDashboardItemClick(kpiData.TilePosition, 'load_ViewDashboard_' + kpiData.TilePosition + '()');
        dashboard.initDashboardItemHover(kpiData.TilePosition);
    },
    removeKpiHtml: function (tilePosition) {
        $('#zone_' + tilePosition)
            .html('<div class="dashcontainerEmptyText">&lt;Dashboard Item ' + tilePosition + '&gt;</div>')
            .addClass('dashcontainerEmpty')
            .removeClass('dashcontainer')
            .css('background-image', '');

        dashboard.initDashboardItemClick(tilePosition, 'load_AddDashboard_' + tilePosition + '()');
        dashboard.killDashboardItemHover(tilePosition);
    },

    loadDashboardFromLocalStorage: function () {

        for (var i = 0; i <= 5; i++) {
            var selectedTile = $('#zone_' + i);
            var isTileAssigned = selectedTile.hasClass('dashcontainer');

            if (isTileAssigned == false) {
                dashboard.initDashboardItemClick(i, 'load_AddDashboard_' + i + '()');
                dashboard.removeKpiHtml(i);
            } else {
                var imageStore = selectedTile.attr('data-imagestorage');
                if (imageStore == 'trylocal') {
                    var item = dashboardCache.getItem(dashboard.iUserId + '_' + i);
                    if (item != null) {
                        dashboard.updateKpiHtml(item);
                    } else {
                        dashboard.initDashboardItemClick(i, 'load_ViewDashboard_' + i + '()');
                        dashboard.initDashboardItemHover(i);
                    }
                } else {
                    dashboard.initDashboardItemClick(i, 'load_ViewDashboard_' + i + '()');
                    dashboard.initDashboardItemHover(i);
                }
                
            }
        }
    },

    initDashboardItemClick: function (tilePosition, onClickString) {
        $('#zone_' + tilePosition).off('click').on('click', function () {
            eval(onClickString);
        });
    },

    initDashboardItemHover: function (tilePosition) {
        $('#zone_' + tilePosition).off('mouseover').on('mouseover', function () {
            $(this).children('.dashboardRemove').show().on('click', function (event) {
                event.stopPropagation();

                $.ajax({
                    type: 'POST',
                    url: dashboard.removeUrlAction,
                    data: { UserId: dashboard.iUserId, TilePosition: tilePosition },
                    success: function () {
                        dashboardCache.removeItem(dashboard.iUserId + '_' + tilePosition);
                        dashboard.removeKpiHtml(tilePosition);
                    },
                    dataType: 'json'
                });
            });
        }).off('mouseout').on('mouseout', function () {
            $(this).children('.dashboardRemove').hide().off('click');
        });
    },

    killDashboardItemHover: function (tilePosition) {
        $('#zone_' + tilePosition).off('mouseover').off('mouseout');
    },

    initDashboard: function (userId, removeAction) {
        if (document.location.href.indexOf('/Main/Dashboard') >= 0) {
            dashboard.iUserId = userId;
            dashboard.removeUrlAction = removeAction;

            dashboard.loadDashboardFromLocalStorage();
        }
    },

    enableLiveDashboardUpdates: function() {
        dashboardService.StartSignalR(dashboard.updateKpi);
    }
}