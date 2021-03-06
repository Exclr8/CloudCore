﻿namespace $safeprojectname$
{
    using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="$ProductDBName$")]
	public partial class $ProductDBName$base : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCloudcore_AccessPool(Cloudcore_AccessPool instance);
    partial void UpdateCloudcore_AccessPool(Cloudcore_AccessPool instance);
    partial void DeleteCloudcore_AccessPool(Cloudcore_AccessPool instance);
    partial void InsertCloudcore_AccessPoolUser(Cloudcore_AccessPoolUser instance);
    partial void UpdateCloudcore_AccessPoolUser(Cloudcore_AccessPoolUser instance);
    partial void DeleteCloudcore_AccessPoolUser(Cloudcore_AccessPoolUser instance);
    partial void InsertCloudcore_Activity(Cloudcore_Activity instance);
    partial void UpdateCloudcore_Activity(Cloudcore_Activity instance);
    partial void DeleteCloudcore_Activity(Cloudcore_Activity instance);
    partial void InsertCloudcore_ActivityAllocation(Cloudcore_ActivityAllocation instance);
    partial void UpdateCloudcore_ActivityAllocation(Cloudcore_ActivityAllocation instance);
    partial void DeleteCloudcore_ActivityAllocation(Cloudcore_ActivityAllocation instance);
    partial void InsertCloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory instance);
    partial void UpdateCloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory instance);
    partial void DeleteCloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory instance);
    partial void InsertCloudcore_ActivityHistory(Cloudcore_ActivityHistory instance);
    partial void UpdateCloudcore_ActivityHistory(Cloudcore_ActivityHistory instance);
    partial void DeleteCloudcore_ActivityHistory(Cloudcore_ActivityHistory instance);
    partial void InsertCloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel instance);
    partial void UpdateCloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel instance);
    partial void DeleteCloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel instance);
    partial void InsertCloudcoremodel_ActivityType(Cloudcoremodel_ActivityType instance);
    partial void UpdateCloudcoremodel_ActivityType(Cloudcoremodel_ActivityType instance);
    partial void DeleteCloudcoremodel_ActivityType(Cloudcoremodel_ActivityType instance);
    partial void InsertCloudcore_Campaign(Cloudcore_Campaign instance);
    partial void UpdateCloudcore_Campaign(Cloudcore_Campaign instance);
    partial void DeleteCloudcore_Campaign(Cloudcore_Campaign instance);
    partial void InsertCloudcore_CampaignArchive(Cloudcore_CampaignArchive instance);
    partial void UpdateCloudcore_CampaignArchive(Cloudcore_CampaignArchive instance);
    partial void DeleteCloudcore_CampaignArchive(Cloudcore_CampaignArchive instance);
    partial void InsertCloudcore_CampaignItem(Cloudcore_CampaignItem instance);
    partial void UpdateCloudcore_CampaignItem(Cloudcore_CampaignItem instance);
    partial void DeleteCloudcore_CampaignItem(Cloudcore_CampaignItem instance);
    partial void InsertCloudcore_CampaignUser(Cloudcore_CampaignUser instance);
    partial void UpdateCloudcore_CampaignUser(Cloudcore_CampaignUser instance);
    partial void DeleteCloudcore_CampaignUser(Cloudcore_CampaignUser instance);
    partial void InsertCloudcore_CostLedger(Cloudcore_CostLedger instance);
    partial void UpdateCloudcore_CostLedger(Cloudcore_CostLedger instance);
    partial void DeleteCloudcore_CostLedger(Cloudcore_CostLedger instance);
    partial void InsertCloudcoremodel_CostType(Cloudcoremodel_CostType instance);
    partial void UpdateCloudcoremodel_CostType(Cloudcoremodel_CostType instance);
    partial void DeleteCloudcoremodel_CostType(Cloudcoremodel_CostType instance);
    partial void InsertCloudcore_Dashboard(Cloudcore_Dashboard instance);
    partial void UpdateCloudcore_Dashboard(Cloudcore_Dashboard instance);
    partial void DeleteCloudcore_Dashboard(Cloudcore_Dashboard instance);
    partial void InsertCloudcore_DashboardRight(Cloudcore_DashboardRight instance);
    partial void UpdateCloudcore_DashboardRight(Cloudcore_DashboardRight instance);
    partial void DeleteCloudcore_DashboardRight(Cloudcore_DashboardRight instance);
    partial void InsertCloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation instance);
    partial void UpdateCloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation instance);
    partial void DeleteCloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation instance);
    partial void InsertCloudcore_Favourite(Cloudcore_Favourite instance);
    partial void UpdateCloudcore_Favourite(Cloudcore_Favourite instance);
    partial void DeleteCloudcore_Favourite(Cloudcore_Favourite instance);
    partial void InsertCloudcoremodel_FlowModel(Cloudcoremodel_FlowModel instance);
    partial void UpdateCloudcoremodel_FlowModel(Cloudcoremodel_FlowModel instance);
    partial void DeleteCloudcoremodel_FlowModel(Cloudcoremodel_FlowModel instance);
    partial void InsertCloudcore_LoginHistory(Cloudcore_LoginHistory instance);
    partial void UpdateCloudcore_LoginHistory(Cloudcore_LoginHistory instance);
    partial void DeleteCloudcore_LoginHistory(Cloudcore_LoginHistory instance);
    partial void InsertCloudcore_Notification(Cloudcore_Notification instance);
    partial void UpdateCloudcore_Notification(Cloudcore_Notification instance);
    partial void DeleteCloudcore_Notification(Cloudcore_Notification instance);
    partial void InsertCloudcore_Period(Cloudcore_Period instance);
    partial void UpdateCloudcore_Period(Cloudcore_Period instance);
    partial void DeleteCloudcore_Period(Cloudcore_Period instance);
    partial void InsertCloudcore_ProcessHistory(Cloudcore_ProcessHistory instance);
    partial void UpdateCloudcore_ProcessHistory(Cloudcore_ProcessHistory instance);
    partial void DeleteCloudcore_ProcessHistory(Cloudcore_ProcessHistory instance);
    partial void InsertCloudcoremodel_ProcessModel(Cloudcoremodel_ProcessModel instance);
    partial void UpdateCloudcoremodel_ProcessModel(Cloudcoremodel_ProcessModel instance);
    partial void DeleteCloudcoremodel_ProcessModel(Cloudcoremodel_ProcessModel instance);
    partial void InsertCloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision instance);
    partial void UpdateCloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision instance);
    partial void DeleteCloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision instance);
    partial void InsertCloudcore_ReferenceType(Cloudcore_ReferenceType instance);
    partial void UpdateCloudcore_ReferenceType(Cloudcore_ReferenceType instance);
    partial void DeleteCloudcore_ReferenceType(Cloudcore_ReferenceType instance);
    partial void InsertCloudcore_ScheduledTask(Cloudcore_ScheduledTask instance);
    partial void UpdateCloudcore_ScheduledTask(Cloudcore_ScheduledTask instance);
    partial void DeleteCloudcore_ScheduledTask(Cloudcore_ScheduledTask instance);
    partial void InsertCloudcore_ScheduledTaskFailed(Cloudcore_ScheduledTaskFailed instance);
    partial void UpdateCloudcore_ScheduledTaskFailed(Cloudcore_ScheduledTaskFailed instance);
    partial void DeleteCloudcore_ScheduledTaskFailed(Cloudcore_ScheduledTaskFailed instance);
    partial void InsertCloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup instance);
    partial void UpdateCloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup instance);
    partial void DeleteCloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup instance);
    partial void InsertCloudcoremodel_StatusType(Cloudcoremodel_StatusType instance);
    partial void UpdateCloudcoremodel_StatusType(Cloudcoremodel_StatusType instance);
    partial void DeleteCloudcoremodel_StatusType(Cloudcoremodel_StatusType instance);
    partial void InsertCloudcoremodel_SubProcess(Cloudcoremodel_SubProcess instance);
    partial void UpdateCloudcoremodel_SubProcess(Cloudcoremodel_SubProcess instance);
    partial void DeleteCloudcoremodel_SubProcess(Cloudcoremodel_SubProcess instance);
    partial void InsertCloudcore_SystemAction(Cloudcore_SystemAction instance);
    partial void UpdateCloudcore_SystemAction(Cloudcore_SystemAction instance);
    partial void DeleteCloudcore_SystemAction(Cloudcore_SystemAction instance);
    partial void InsertCloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation instance);
    partial void UpdateCloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation instance);
    partial void DeleteCloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation instance);
    partial void InsertCloudcore_SystemApplication(Cloudcore_SystemApplication instance);
    partial void UpdateCloudcore_SystemApplication(Cloudcore_SystemApplication instance);
    partial void DeleteCloudcore_SystemApplication(Cloudcore_SystemApplication instance);
    partial void InsertCloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation instance);
    partial void UpdateCloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation instance);
    partial void DeleteCloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation instance);
    partial void InsertCloudcore_SystemMenu(Cloudcore_SystemMenu instance);
    partial void UpdateCloudcore_SystemMenu(Cloudcore_SystemMenu instance);
    partial void DeleteCloudcore_SystemMenu(Cloudcore_SystemMenu instance);
    partial void InsertCloudcore_SystemModule(Cloudcore_SystemModule instance);
    partial void UpdateCloudcore_SystemModule(Cloudcore_SystemModule instance);
    partial void DeleteCloudcore_SystemModule(Cloudcore_SystemModule instance);
    partial void InsertCloudcore_SystemTally(Cloudcore_SystemTally instance);
    partial void UpdateCloudcore_SystemTally(Cloudcore_SystemTally instance);
    partial void DeleteCloudcore_SystemTally(Cloudcore_SystemTally instance);
    partial void InsertCloudcore_SystemValue(Cloudcore_SystemValue instance);
    partial void UpdateCloudcore_SystemValue(Cloudcore_SystemValue instance);
    partial void DeleteCloudcore_SystemValue(Cloudcore_SystemValue instance);
    partial void InsertCloudcore_SystemValueCategory(Cloudcore_SystemValueCategory instance);
    partial void UpdateCloudcore_SystemValueCategory(Cloudcore_SystemValueCategory instance);
    partial void DeleteCloudcore_SystemValueCategory(Cloudcore_SystemValueCategory instance);
    partial void InsertCloudcore_User(Cloudcore_User instance);
    partial void UpdateCloudcore_User(Cloudcore_User instance);
    partial void DeleteCloudcore_User(Cloudcore_User instance);
    partial void InsertCloudcore_UserAccessMapping(Cloudcore_UserAccessMapping instance);
    partial void UpdateCloudcore_UserAccessMapping(Cloudcore_UserAccessMapping instance);
    partial void DeleteCloudcore_UserAccessMapping(Cloudcore_UserAccessMapping instance);
    partial void InsertCloudcore_UserAccessProvider(Cloudcore_UserAccessProvider instance);
    partial void UpdateCloudcore_UserAccessProvider(Cloudcore_UserAccessProvider instance);
    partial void DeleteCloudcore_UserAccessProvider(Cloudcore_UserAccessProvider instance);
    partial void InsertCloudcore_UserNotification(Cloudcore_UserNotification instance);
    partial void UpdateCloudcore_UserNotification(Cloudcore_UserNotification instance);
    partial void DeleteCloudcore_UserNotification(Cloudcore_UserNotification instance);
    partial void InsertCloudcore_Worklist(Cloudcore_Worklist instance);
    partial void UpdateCloudcore_Worklist(Cloudcore_Worklist instance);
    partial void DeleteCloudcore_Worklist(Cloudcore_Worklist instance);
    partial void InsertCloudcore_WorklistFailure(Cloudcore_WorklistFailure instance);
    partial void UpdateCloudcore_WorklistFailure(Cloudcore_WorklistFailure instance);
    partial void DeleteCloudcore_WorklistFailure(Cloudcore_WorklistFailure instance);
    partial void InsertCloudcore_WorklistReference(Cloudcore_WorklistReference instance);
    partial void UpdateCloudcore_WorklistReference(Cloudcore_WorklistReference instance);
    partial void DeleteCloudcore_WorklistReference(Cloudcore_WorklistReference instance);
    #endregion
		
		public $ProductDBName$base(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public $ProductDBName$base(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public $ProductDBName$base(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public $ProductDBName$base(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Cloudcore_AccessPool> Cloudcore_AccessPool
		{
			get
			{
				return this.GetTable<Cloudcore_AccessPool>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_AccessPoolUser> Cloudcore_AccessPoolUser
		{
			get
			{
				return this.GetTable<Cloudcore_AccessPoolUser>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Activity> Cloudcore_Activity
		{
			get
			{
				return this.GetTable<Cloudcore_Activity>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ActivityAllocation> Cloudcore_ActivityAllocation
		{
			get
			{
				return this.GetTable<Cloudcore_ActivityAllocation>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ActivityFailureHistory> Cloudcore_ActivityFailureHistory
		{
			get
			{
				return this.GetTable<Cloudcore_ActivityFailureHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ActivityHistory> Cloudcore_ActivityHistory
		{
			get
			{
				return this.GetTable<Cloudcore_ActivityHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_ActivityModel> Cloudcoremodel_ActivityModel
		{
			get
			{
				return this.GetTable<Cloudcoremodel_ActivityModel>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_ActivityType> Cloudcoremodel_ActivityType
		{
			get
			{
				return this.GetTable<Cloudcoremodel_ActivityType>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Campaign> Cloudcore_Campaign
		{
			get
			{
				return this.GetTable<Cloudcore_Campaign>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_CampaignArchive> Cloudcore_CampaignArchive
		{
			get
			{
				return this.GetTable<Cloudcore_CampaignArchive>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_CampaignItem> Cloudcore_CampaignItem
		{
			get
			{
				return this.GetTable<Cloudcore_CampaignItem>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_CampaignUser> Cloudcore_CampaignUser
		{
			get
			{
				return this.GetTable<Cloudcore_CampaignUser>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_CostLedger> Cloudcore_CostLedger
		{
			get
			{
				return this.GetTable<Cloudcore_CostLedger>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_CostType> Cloudcoremodel_CostType
		{
			get
			{
				return this.GetTable<Cloudcoremodel_CostType>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Dashboard> Cloudcore_Dashboard
		{
			get
			{
				return this.GetTable<Cloudcore_Dashboard>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_DashboardRight> Cloudcore_DashboardRight
		{
			get
			{
				return this.GetTable<Cloudcore_DashboardRight>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_DashboardUserAllocation> Cloudcore_DashboardUserAllocation
		{
			get
			{
				return this.GetTable<Cloudcore_DashboardUserAllocation>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Favourite> Cloudcore_Favourite
		{
			get
			{
				return this.GetTable<Cloudcore_Favourite>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_FlowModel> Cloudcoremodel_FlowModel
		{
			get
			{
				return this.GetTable<Cloudcoremodel_FlowModel>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_LoginHistory> Cloudcore_LoginHistory
		{
			get
			{
				return this.GetTable<Cloudcore_LoginHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Notification> Cloudcore_Notification
		{
			get
			{
				return this.GetTable<Cloudcore_Notification>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Period> Cloudcore_Period
		{
			get
			{
				return this.GetTable<Cloudcore_Period>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ProcessHistory> Cloudcore_ProcessHistory
		{
			get
			{
				return this.GetTable<Cloudcore_ProcessHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_ProcessModel> Cloudcoremodel_ProcessModel
		{
			get
			{
				return this.GetTable<Cloudcoremodel_ProcessModel>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_ProcessRevision> Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this.GetTable<Cloudcoremodel_ProcessRevision>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ReferenceType> Cloudcore_ReferenceType
		{
			get
			{
				return this.GetTable<Cloudcore_ReferenceType>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ScheduledTask> Cloudcore_ScheduledTask
		{
			get
			{
				return this.GetTable<Cloudcore_ScheduledTask>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ScheduledTaskFailed> Cloudcore_ScheduledTaskFailed
		{
			get
			{
				return this.GetTable<Cloudcore_ScheduledTaskFailed>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_ScheduledTaskGroup> Cloudcore_ScheduledTaskGroup
		{
			get
			{
				return this.GetTable<Cloudcore_ScheduledTaskGroup>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_StatusType> Cloudcoremodel_StatusType
		{
			get
			{
				return this.GetTable<Cloudcoremodel_StatusType>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_SubProcess> Cloudcoremodel_SubProcess
		{
			get
			{
				return this.GetTable<Cloudcoremodel_SubProcess>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemAction> Cloudcore_SystemAction
		{
			get
			{
				return this.GetTable<Cloudcore_SystemAction>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemActionAllocation> Cloudcore_SystemActionAllocation
		{
			get
			{
				return this.GetTable<Cloudcore_SystemActionAllocation>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemApplication> Cloudcore_SystemApplication
		{
			get
			{
				return this.GetTable<Cloudcore_SystemApplication>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemApplicationAllocation> Cloudcore_SystemApplicationAllocation
		{
			get
			{
				return this.GetTable<Cloudcore_SystemApplicationAllocation>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemMenu> Cloudcore_SystemMenu
		{
			get
			{
				return this.GetTable<Cloudcore_SystemMenu>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemModule> Cloudcore_SystemModule
		{
			get
			{
				return this.GetTable<Cloudcore_SystemModule>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemTally> Cloudcore_SystemTally
		{
			get
			{
				return this.GetTable<Cloudcore_SystemTally>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemValue> Cloudcore_SystemValue
		{
			get
			{
				return this.GetTable<Cloudcore_SystemValue>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_SystemValueCategory> Cloudcore_SystemValueCategory
		{
			get
			{
				return this.GetTable<Cloudcore_SystemValueCategory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_User> Cloudcore_User
		{
			get
			{
				return this.GetTable<Cloudcore_User>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_UserAccessMapping> Cloudcore_UserAccessMapping
		{
			get
			{
				return this.GetTable<Cloudcore_UserAccessMapping>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_UserAccessProvider> Cloudcore_UserAccessProvider
		{
			get
			{
				return this.GetTable<Cloudcore_UserAccessProvider>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_UserNotification> Cloudcore_UserNotification
		{
			get
			{
				return this.GetTable<Cloudcore_UserNotification>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwAccessPool> Cloudcore_VwAccessPool
		{
			get
			{
				return this.GetTable<Cloudcore_VwAccessPool>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwActivityAllocationPriority> Cloudcore_VwActivityAllocationPriority
		{
			get
			{
				return this.GetTable<Cloudcore_VwActivityAllocationPriority>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCampaign> Cloudcore_VwCampaign
		{
			get
			{
				return this.GetTable<Cloudcore_VwCampaign>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCampaignDailyStats> Cloudcore_VwCampaignDailyStats
		{
			get
			{
				return this.GetTable<Cloudcore_VwCampaignDailyStats>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCampaignManager> Cloudcore_VwCampaignManager
		{
			get
			{
				return this.GetTable<Cloudcore_VwCampaignManager>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCampaignStats> Cloudcore_VwCampaignStats
		{
			get
			{
				return this.GetTable<Cloudcore_VwCampaignStats>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCampaignUserStats> Cloudcore_VwCampaignUserStats
		{
			get
			{
				return this.GetTable<Cloudcore_VwCampaignUserStats>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwCostLedger> Cloudcore_VwCostLedger
		{
			get
			{
				return this.GetTable<Cloudcore_VwCostLedger>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwLedgerInfo> Cloudcore_VwLedgerInfo
		{
			get
			{
				return this.GetTable<Cloudcore_VwLedgerInfo>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_VwLiveActivity> Cloudcoremodel_VwLiveActivity
		{
			get
			{
				return this.GetTable<Cloudcoremodel_VwLiveActivity>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_VwLiveFlow> Cloudcoremodel_VwLiveFlow
		{
			get
			{
				return this.GetTable<Cloudcoremodel_VwLiveFlow>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_VwLiveFlowDetails> Cloudcoremodel_VwLiveFlowDetails
		{
			get
			{
				return this.GetTable<Cloudcoremodel_VwLiveFlowDetails>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_VwLiveProcess> Cloudcoremodel_VwLiveProcess
		{
			get
			{
				return this.GetTable<Cloudcoremodel_VwLiveProcess>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwNotificationHistory> Cloudcore_VwNotificationHistory
		{
			get
			{
				return this.GetTable<Cloudcore_VwNotificationHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwOpenTasks> Cloudcore_VwOpenTasks
		{
			get
			{
				return this.GetTable<Cloudcore_VwOpenTasks>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwProcessDailyStats> Cloudcore_VwProcessDailyStats
		{
			get
			{
				return this.GetTable<Cloudcore_VwProcessDailyStats>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcoremodel_VwProcessModel> Cloudcoremodel_VwProcessModel
		{
			get
			{
				return this.GetTable<Cloudcoremodel_VwProcessModel>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwProcessStats> Cloudcore_VwProcessStats
		{
			get
			{
				return this.GetTable<Cloudcore_VwProcessStats>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwTasklist> Cloudcore_VwTasklist
		{
			get
			{
				return this.GetTable<Cloudcore_VwTasklist>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwTaskListFilter> Cloudcore_VwTaskListFilter
		{
			get
			{
				return this.GetTable<Cloudcore_VwTaskListFilter>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwTasklistHistory> Cloudcore_VwTasklistHistory
		{
			get
			{
				return this.GetTable<Cloudcore_VwTasklistHistory>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserAccess> Cloudcore_VwUserAccess
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserAccess>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserDashboard> Cloudcore_VwUserDashboard
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserDashboard>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserModule> Cloudcore_VwUserModule
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserModule>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserMonthlyTaskAgeAverage> Cloudcore_VwUserMonthlyTaskAgeAverage
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserMonthlyTaskAgeAverage>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserMonthlyTaskCompletedCount> Cloudcore_VwUserMonthlyTaskCompletedCount
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserMonthlyTaskCompletedCount>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserNotification> Cloudcore_VwUserNotification
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserNotification>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwUserWeeklyTaskCompletedCount> Cloudcore_VwUserWeeklyTaskCompletedCount
		{
			get
			{
				return this.GetTable<Cloudcore_VwUserWeeklyTaskCompletedCount>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwWorklist> Cloudcore_VwWorklist
		{
			get
			{
				return this.GetTable<Cloudcore_VwWorklist>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_VwWorklistEx> Cloudcore_VwWorklistEx
		{
			get
			{
				return this.GetTable<Cloudcore_VwWorklistEx>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_Worklist> Cloudcore_Worklist
		{
			get
			{
				return this.GetTable<Cloudcore_Worklist>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_WorklistFailure> Cloudcore_WorklistFailure
		{
			get
			{
				return this.GetTable<Cloudcore_WorklistFailure>();
			}
		}
		
		public System.Data.Linq.Table<Cloudcore_WorklistReference> Cloudcore_WorklistReference
		{
			get
			{
				return this.GetTable<Cloudcore_WorklistReference>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.AccessPoolCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_AccessPoolCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] ref System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolName", DbType="VarChar(50)")] string accessPoolName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ManagerId", DbType="Int")] System.Nullable<int> managerId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, accessPoolName, managerId);
			accessPoolId = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.AccessPoolUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_AccessPoolUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolName", DbType="VarChar(50)")] string accessPoolName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ManagerId", DbType="Int")] System.Nullable<int> managerId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, accessPoolName, managerId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.AccessPoolUserCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_AccessPoolUserCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.AccessPoolUserRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_AccessPoolUserRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActionAllocationCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActionAllocationCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, actionId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActionAllocationRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActionAllocationRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, actionId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivityAllocationCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivityAllocationCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityId, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivityAllocationDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivityAllocationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityId, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivityBatchSpawn")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivityBatchSpawn([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PInstanceId", DbType="BigInt")] System.Nullable<long> pInstanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Activate", DbType="DateTime")] System.Nullable<System.DateTime> activate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DocWait", DbType="Int")] System.Nullable<int> docWait, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Priority", DbType="TinyInt")] System.Nullable<byte> priority, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pInstanceId, activityGuid, keyValue, activate, docWait, priority, userId, instanceId);
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivityByPass")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivityByPass([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] System.Nullable<long> keyValue)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityGuid, keyValue);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivitySpawn")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivitySpawn([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Activate", DbType="DateTime")] System.Nullable<System.DateTime> activate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DocWait", DbType="Int")] System.Nullable<int> docWait, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Priority", DbType="TinyInt")] System.Nullable<byte> priority, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityGuid, keyValue, activate, docWait, priority, userId, instanceId);
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(6)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ActivityStart")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ActivityStart([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityGuid, keyValue, userId, instanceId);
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(3)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ApplicationAllocationCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ApplicationAllocationCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, activityId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ApplicationAllocationDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ApplicationAllocationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, activityId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CalculateNextInitDate", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")]
		public System.Nullable<System.DateTime> Cloudcore_CalculateNextInitDate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InitDate", DbType="DateTime")] System.Nullable<System.DateTime> initDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalType", DbType="TinyInt")] System.Nullable<byte> intervalType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalValue", DbType="Int")] System.Nullable<int> intervalValue)
		{
			return ((System.Nullable<System.DateTime>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), initDate, intervalType, intervalValue).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CalculateNextRunDate", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")]
		public System.Nullable<System.DateTime> Cloudcore_CalculateNextRunDate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InitDate", DbType="DateTime")] System.Nullable<System.DateTime> initDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalType", DbType="TinyInt")] System.Nullable<byte> intervalType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalValue", DbType="Int")] System.Nullable<int> intervalValue)
		{
			return ((System.Nullable<System.DateTime>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), initDate, intervalType, intervalValue).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignArc")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignArc([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignID", DbType="Int")] System.Nullable<int> campaignID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), campaignID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignCancel")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignCancel([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignID", DbType="Int")] System.Nullable<int> campaignID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), campaignID, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignHandover")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignHandover([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignID", DbType="Int")] System.Nullable<int> campaignID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ManagerId", DbType="Int")] System.Nullable<int> managerId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), campaignID, managerId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignItemFinish")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignItemFinish([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignUserCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignUserCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignID", DbType="Int")] System.Nullable<int> campaignID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), campaignID, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CampaignUserDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_CampaignUserDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignID", DbType="Int")] System.Nullable<int> campaignID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), campaignID, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CreatePasswordHash", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")]
		public string Cloudcore_CreatePasswordHash([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="VarChar(100)")] string password)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, password).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.CreateUniqueKey", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")]
		public string Cloudcore_CreateUniqueKey([global::System.Data.Linq.Mapping.ParameterAttribute(Name="L3REF", DbType="VarChar(3)")] string l3REF, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UNIQUEID", DbType="Int")] System.Nullable<int> uNIQUEID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="LENGTH", DbType="Int")] System.Nullable<int> lENGTH)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), l3REF, uNIQUEID, lENGTH).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.DashboardCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_DashboardCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DashboardID", DbType="Int")] ref System.Nullable<int> dashboardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ClassName", DbType="VarChar(100)")] string className, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Title", DbType="VarChar(100)")] string title, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="VarChar(MAX)")] string description)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dashboardID, systemModuleId, className, title, description);
			dashboardID = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.DashboardDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_DashboardDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DashboardID", DbType="Int")] System.Nullable<int> dashboardID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dashboardID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.DashboardModify")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_DashboardModify([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DashboardId", DbType="Int")] System.Nullable<int> dashboardId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Title", DbType="VarChar(100)")] string title, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="VarChar(MAX)")] string description)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dashboardId, title, description);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.DashboardRightCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_DashboardRightCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DashboardId", DbType="Int")] System.Nullable<int> dashboardId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dashboardId, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.DashboardRightDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_DashboardRightDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DashboardID", DbType="Int")] System.Nullable<int> dashboardID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dashboardID, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.FavouriteAdd")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_FavouriteAdd([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FavouriteReference", DbType="VarChar(50)")] string favouriteReference, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FavouriteTypeId", DbType="Int")] System.Nullable<int> favouriteTypeId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, favouriteReference, favouriteTypeId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.FavouriteRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_FavouriteRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FavouriteReference", DbType="VarChar(50)")] string favouriteReference, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FavouriteTypeId", DbType="Int")] System.Nullable<int> favouriteTypeId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, favouriteReference, favouriteTypeId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.FlowHasTrigger", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")]
		public System.Nullable<bool> Cloudcore_FlowHasTrigger([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FlowGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> flowGuid)
		{
			return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), flowGuid).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.GenerateUniqueKey", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")]
		public string Cloudcore_GenerateUniqueKey([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Prefix", DbType="VarChar(3)")] string prefix, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UniqueId", DbType="Int")] System.Nullable<int> uniqueId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Length", DbType="Int")] System.Nullable<int> length)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prefix, uniqueId, length).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.LoginDetailsGet")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_LoginDetailsGet([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Login", DbType="VarChar(320)")] string login, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] ref System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PasswordHash", DbType="VarChar(64)")] ref string passwordHash)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), login, userId, passwordHash);
			userId = ((System.Nullable<int>)(result.GetParameterValue(1)));
			passwordHash = ((string)(result.GetParameterValue(2)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.LoginUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_LoginUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.MaintainPeriods")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_MaintainPeriods()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.MenuSearch")]
		public ISingleResult<Cloudcore_MenuSearchResult> Cloudcore_MenuSearch([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(255)")] string searchterm)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, searchterm);
			return ((ISingleResult<Cloudcore_MenuSearchResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.MenuSelect")]
		public ISingleResult<Cloudcore_MenuSelectResult> Cloudcore_MenuSelect([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId);
			return ((ISingleResult<Cloudcore_MenuSelectResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ModuleAuthorizationCheck", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")]
		public System.Nullable<bool> Cloudcore_ModuleAuthorizationCheck([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntAccess", DbType="Bit")] System.Nullable<bool> intAccess, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ExtAccess", DbType="Bit")] System.Nullable<bool> extAccess, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), intAccess, extAccess, userId).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationCreateByAccessPool")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationCreateByAccessPool([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Creator", DbType="Int")] System.Nullable<int> creator, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Subject", DbType="VarChar(50)")] string subject, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Message", DbType="VarChar(1000)")] string message)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), accessPoolId, creator, subject, message);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationCreateByUser")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationCreateByUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Creator", DbType="Int")] System.Nullable<int> creator, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Subject", DbType="VarChar(50)")] string subject, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Message", DbType="VarChar(1000)")] string message)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, creator, subject, message);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NotificationId", DbType="Int")] System.Nullable<int> notificationId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), notificationId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationMarkAsRead")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationMarkAsRead([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NotificationId", DbType="Int")] System.Nullable<int> notificationId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, notificationId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NotificationId", DbType="Int")] System.Nullable<int> notificationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), notificationId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.NotificationRemoveAll")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_NotificationRemoveAll([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.Ordinals", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")]
		public string Cloudcore_Ordinals([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Number", DbType="Int")] System.Nullable<int> number)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), number).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.Period_Get", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public System.Nullable<int> Cloudcore_Period_Get([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DATE", DbType="DateTime")] System.Nullable<System.DateTime> dATE)
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dATE).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.Period_Today", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public System.Nullable<int> Cloudcore_Period_Today()
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.PeriodCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_PeriodCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="StartDate", DbType="DateTime")] System.Nullable<System.DateTime> startDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EndDate", DbType="DateTime")] System.Nullable<System.DateTime> endDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodMonth", DbType="Int")] System.Nullable<int> periodMonth, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodYear", DbType="Int")] System.Nullable<int> periodYear)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), startDate, endDate, periodMonth, periodYear);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.PeriodDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_PeriodDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodSeq", DbType="Int")] System.Nullable<int> periodSeq)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), periodSeq);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.PeriodModify")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_PeriodModify([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodSeq", DbType="Int")] System.Nullable<int> periodSeq, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="StartDate", DbType="DateTime")] System.Nullable<System.DateTime> startDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EndDate", DbType="DateTime")] System.Nullable<System.DateTime> endDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodMonth", DbType="Int")] System.Nullable<int> periodMonth, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PeriodYear", DbType="Int")] System.Nullable<int> periodYear)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), periodSeq, startDate, endDate, periodMonth, periodYear);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ProcessChangeOwner")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ProcessChangeOwner([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessRevisionId", DbType="Int")] System.Nullable<int> processRevisionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ManagerId", DbType="Int")] System.Nullable<int> managerId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processRevisionId, managerId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.PROPER", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(255)")]
		public string Cloudcore_PROPER([global::System.Data.Linq.Mapping.ParameterAttribute(Name="STRING", DbType="VarChar(255)")] string sTRING)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sTRING).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.RestartFailedWorklistItem")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_RestartFailedWorklistItem([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="Int")] System.Nullable<int> instanceId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.RestartFailedWorklistItemByActivity")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_RestartFailedWorklistItemByActivity([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.RestartFailedWorklistItemByProcess")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_RestartFailedWorklistItemByProcess([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessRevisionId", DbType="Int")] System.Nullable<int> processRevisionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processRevisionId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.RestartFailedWorklistItemBySubProcess")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_RestartFailedWorklistItemBySubProcess([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubProcessId", DbType="Int")] System.Nullable<int> subProcessId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), subProcessId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskActivate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskActivate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskId", DbType="Int")] System.Nullable<int> scheduledTaskId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), scheduledTaskId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskDeploy")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskDeploy([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskGroupGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> scheduledTaskGroupGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> scheduledTaskGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskName", DbType="VarChar(50)")] string scheduledTaskName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskTypeId", DbType="TinyInt")] System.Nullable<byte> scheduledTaskTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalType", DbType="TinyInt")] System.Nullable<byte> intervalType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalValue", DbType="Int")] System.Nullable<int> intervalValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="StartDate", DbType="DateTime")] System.Nullable<System.DateTime> startDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskId", DbType="Int")] ref System.Nullable<int> scheduledTaskId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), scheduledTaskGroupGuid, scheduledTaskGuid, scheduledTaskName, scheduledTaskTypeId, systemModuleId, intervalType, intervalValue, startDate, scheduledTaskId);
			scheduledTaskId = ((System.Nullable<int>)(result.GetParameterValue(8)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskExecutionFailed")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskExecutionFailed([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskId", DbType="Int")] System.Nullable<int> scheduledTaskId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Reason", DbType="VarChar(MAX)")] string reason)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), scheduledTaskId, reason);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskFinish")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskFinish([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskId", DbType="Int")] System.Nullable<int> scheduledTaskId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), scheduledTaskId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskGroupDeploy")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskGroupDeploy([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Guid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> guid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="GroupName", DbType="VarChar(50)")] string groupName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskGroupId", DbType="Int")] ref System.Nullable<int> scheduledTaskGroupId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), guid, groupName, systemModuleId, scheduledTaskGroupId);
			scheduledTaskGroupId = ((System.Nullable<int>)(result.GetParameterValue(3)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskListGet")]
		public ISingleResult<Cloudcore_ScheduledTaskListGetResult> Cloudcore_ScheduledTaskListGet()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<Cloudcore_ScheduledTaskListGetResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ScheduledTaskUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_ScheduledTaskUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskId", DbType="Int")] System.Nullable<int> scheduledTaskId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ScheduledTaskName", DbType="VarChar(50)")] string scheduledTaskName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalValue", DbType="Int")] System.Nullable<int> intervalValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntervalType", DbType="TinyInt")] System.Nullable<byte> intervalType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NextRunDate", DbType="DateTime")] System.Nullable<System.DateTime> nextRunDate, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsActive", DbType="Bit")] System.Nullable<bool> isActive)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), scheduledTaskId, scheduledTaskName, intervalValue, intervalType, nextRunDate, isActive);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.ServerInfo")]
		public ISingleResult<Cloudcore_ServerInfoResult> Cloudcore_ServerInfo([global::System.Data.Linq.Mapping.ParameterAttribute(Name="DBName", DbType="VarChar(256)")] string dBName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), dBName);
			return ((ISingleResult<Cloudcore_ServerInfoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.Split", IsComposable=true)]
		public IQueryable<Cloudcore_SplitResult> Cloudcore_Split([global::System.Data.Linq.Mapping.ParameterAttribute(Name="String", DbType="VarChar(8000)")] string @string, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Delimiter", DbType="Char(1)")] string delimiter)
		{
			return this.CreateMethodCallQuery<Cloudcore_SplitResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @string, delimiter);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SProcessDailyStats")]
		public ISingleResult<Cloudcore_SProcessDailyStatsResult> Cloudcore_SProcessDailyStats([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessModelId", DbType="Int")] System.Nullable<int> processModelId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processModelId);
			return ((ISingleResult<Cloudcore_SProcessDailyStatsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SProcessTop10TaskAge")]
		public ISingleResult<Cloudcore_SProcessTop10TaskAgeResult> Cloudcore_SProcessTop10TaskAge([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessModelId", DbType="Int")] System.Nullable<int> processModelId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processModelId);
			return ((ISingleResult<Cloudcore_SProcessTop10TaskAgeResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.STaskSummary")]
		public ISingleResult<Cloudcore_STaskSummaryResult> Cloudcore_STaskSummary([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalCnt", DbType="Int")] ref System.Nullable<int> totalCnt)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, totalCnt);
			totalCnt = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((ISingleResult<Cloudcore_STaskSummaryResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SUserProcessOverview")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SUserProcessOverview([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalCnt", DbType="Int")] ref System.Nullable<int> totalCnt)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, totalCnt);
			totalCnt = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemActionAllocationCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemActionAllocationCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionId, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemActionAllocationDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemActionAllocationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionId, accessPoolId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemActionCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemActionCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> actionGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionTitle", DbType="VarChar(50)")] string actionTitle, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Area", DbType="VarChar(100)")] string area, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Controller", DbType="VarChar(100)")] string controller, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Action", DbType="VarChar(100)")] string action, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionType", DbType="VarChar(10)")] string actionType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] ref System.Nullable<int> actionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionGuid, actionTitle, area, controller, action, actionType, systemModuleId, actionId);
			actionId = ((System.Nullable<int>)(result.GetParameterValue(7)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemActionDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemActionDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemActionModify")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemActionModify([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionTitle", DbType="VarChar(50)")] string actionTitle, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Area", DbType="VarChar(100)")] string area, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Controller", DbType="VarChar(100)")] string controller, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Action", DbType="VarChar(100)")] string action, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionType", DbType="VarChar(10)")] string actionType, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionId, actionTitle, area, controller, action, actionType, systemModuleId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemApplicationCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemApplicationCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationName", DbType="VarChar(100)")] string applicationName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CompanyName", DbType="VarChar(100)")] string companyName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PersonName", DbType="VarChar(100)")] string personName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ContactNumber", DbType="VarChar(50)")] string contactNumber, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] ref System.Nullable<int> applicationId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationName, companyName, personName, contactNumber, applicationId);
			applicationId = ((System.Nullable<int>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemApplicationDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemApplicationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemApplicationUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemApplicationUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationName", DbType="VarChar(100)")] string applicationName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CompanyName", DbType="VarChar(100)")] string companyName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PersonName", DbType="VarChar(100)")] string personName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ContactNumber", DbType="VarChar(100)")] string contactNumber)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, applicationName, companyName, personName, contactNumber);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemCategoryCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemCategoryCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryName", DbType="VarChar(100)")] string categoryName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryId", DbType="Int")] ref System.Nullable<int> categoryId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryName, categoryId);
			categoryId = ((System.Nullable<int>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemMenuCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemMenuCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActionId", DbType="Int")] System.Nullable<int> actionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentActionId", DbType="Int")] System.Nullable<int> parentActionId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), actionId, parentActionId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemMenuModuleRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemMenuModuleRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), systemModuleId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemModuleRemove")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemModuleRemove([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), systemModuleId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemModuleSetEnabledStatus")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemModuleSetEnabledStatus([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Enabled", DbType="Bit")] System.Nullable<bool> enabled)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), systemModuleId, enabled);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemModuleUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemModuleUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DefaultNamespace", DbType="VarChar(100)")] string defaultNamespace, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ModuleTypeId", DbType="TinyInt")] System.Nullable<byte> moduleTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Enabled", DbType="Bit")] System.Nullable<bool> enabled)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), systemModuleId, defaultNamespace, moduleTypeId, enabled);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemModuleUpload")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemModuleUpload([global::System.Data.Linq.Mapping.ParameterAttribute(Name="AssemblyName", DbType="VarChar(50)")] string assemblyName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DefaultNamespace", DbType="VarChar(100)")] string defaultNamespace, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ModuleTypeId", DbType="TinyInt")] System.Nullable<byte> moduleTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] ref System.Nullable<int> systemModuleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), assemblyName, defaultNamespace, moduleTypeId, systemModuleId);
			systemModuleId = ((System.Nullable<int>)(result.GetParameterValue(3)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemValue_GetValueData", IsComposable=true)]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(MAX)")]
		public string Cloudcore_SystemValue_GetValueData([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryName", DbType="VarChar(50)")] string categoryName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueName", DbType="VarChar(50)")] string valueName)
		{
			return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryName, valueName).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemValueCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemValueCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryId", DbType="Int")] System.Nullable<int> categoryId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueName", DbType="VarChar(50)")] string valueName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueData", DbType="VarChar(MAX)")] string valueData, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueDescription", DbType="VarChar(1000)")] string valueDescription)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryId, valueName, valueData, valueDescription);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.SystemValueUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_SystemValueUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryId", DbType="Int")] System.Nullable<int> categoryId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueName", DbType="VarChar(50)")] string valueName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueData", DbType="VarChar(MAX)")] string valueData, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ValueDescription", DbType="VarChar(1000)")] string valueDescription)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryId, valueName, valueData, valueDescription);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UpdateUserImage")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UpdateUserImage([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Image")] System.Data.Linq.Binary mainImage, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Image")] System.Data.Linq.Binary thumbImage, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), mainImage, thumbImage, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserACSCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserACSCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FullName", DbType="VarChar(500)")] string fullName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessProviderId", DbType="Int")] System.Nullable<int> accessProviderId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserKey", DbType="VarChar(255)")] string userKey, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] ref System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fullName, email, accessProviderId, userKey, userId);
			userId = ((System.Nullable<int>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserActivateInternal")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserActivateInternal([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntAccess", DbType="Bit")] System.Nullable<bool> intAccess)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, intAccess);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserCampaignSelect")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserCampaignSelect([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CampaignId", DbType="Int")] System.Nullable<int> campaignId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, campaignId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Login", DbType="VarChar(320)")] string login, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Account", DbType="VarChar(50)")] string account, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Initials", DbType="VarChar(15)")] string initials, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Firstnames", DbType="VarChar(100)")] string firstnames, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Surname", DbType="VarChar(30)")] string surname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Preferredname", DbType="VarChar(20)")] string preferredname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CellNo", DbType="VarChar(15)")] string cellNo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PasswordHash", DbType="VarChar(50)")] string passwordHash, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntAccess", DbType="Bit")] System.Nullable<bool> intAccess, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ExtAccess", DbType="Bit")] System.Nullable<bool> extAccess, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="AccessPoolId", DbType="Int")] System.Nullable<int> accessPoolId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] ref System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), login, account, email, initials, firstnames, surname, preferredname, cellNo, passwordHash, intAccess, extAccess, accessPoolId, userId);
			userId = ((System.Nullable<int>)(result.GetParameterValue(12)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserModify")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserModify([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Initials", DbType="VarChar(15)")] string initials, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Firstnames", DbType="VarChar(100)")] string firstnames, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Preferredname", DbType="VarChar(20)")] string preferredname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Surname", DbType="VarChar(30)")] string surname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Cellno", DbType="VarChar(15)")] string cellno, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IntAccess", DbType="Bit")] System.Nullable<bool> intAccess)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, initials, firstnames, preferredname, surname, cellno, email, intAccess);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.UserPasswordUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_UserPasswordUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="PasswordHash", DbType="VarChar(37)")] string passwordHash)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, passwordHash);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemCancel")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemCancel([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemChangePriority")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemChangePriority([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="Int")] System.Nullable<int> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Priority", DbType="TinyInt")] System.Nullable<byte> priority)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, priority);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemChangeUser")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemChangeUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemDelay")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemDelay([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ReactivateAt", DbType="DateTime")] System.Nullable<System.DateTime> reactivateAt)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, reactivateAt);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemFail")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemFail([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Reason", DbType="VarChar(MAX)")] string reason)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, reason);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemFlow")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemFlow([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Outcome", DbType="VarChar(30)")] string outcome)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId, userId, outcome);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemFlowCosting")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemFlowCosting([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityModelId", DbType="Int")] System.Nullable<int> activityModelId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Cost", DbType="Money")] System.Nullable<decimal> cost)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), activityModelId, instanceId, cost);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemRelease")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemRelease([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instanceId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemStartByActivity")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemStartByActivity([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] System.Nullable<int> activityId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] ref System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubProcessGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> subProcessGuid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, activityId, instanceId, keyValue, activityGuid, subProcessGuid);
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(2)));
			keyValue = ((System.Nullable<long>)(result.GetParameterValue(3)));
			activityGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(4)));
			subProcessGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(5)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemStartByInstance")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemStartByInstance([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] ref System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubProcessGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> subProcessGuid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId, instanceId, keyValue, activityGuid, subProcessGuid);
			keyValue = ((System.Nullable<long>)(result.GetParameterValue(2)));
			activityGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(3)));
			subProcessGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemStartFromVirtualWorker")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemStartFromVirtualWorker([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] ref System.Nullable<int> activityId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] ref System.Nullable<long> keyValue)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, activityGuid, activityId, instanceId, keyValue);
			activityGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(1)));
			activityId = ((System.Nullable<int>)(result.GetParameterValue(2)));
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(3)));
			keyValue = ((System.Nullable<long>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcore.WorkItemStartFromVirtualWorkerByLocation")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcore_WorkItemStartFromVirtualWorkerByLocation([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ApplicationId", DbType="Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityId", DbType="Int")] ref System.Nullable<int> activityId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstanceId", DbType="BigInt")] ref System.Nullable<long> instanceId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KeyValue", DbType="BigInt")] ref System.Nullable<long> keyValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Latitude", DbType="Decimal(13,10)")] System.Nullable<decimal> latitude, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Longitude", DbType="Decimal(13,10)")] System.Nullable<decimal> longitude, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="RadiusInMeters", DbType="Int")] System.Nullable<int> radiusInMeters)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, activityGuid, activityId, instanceId, keyValue, latitude, longitude, radiusInMeters);
			activityGuid = ((System.Nullable<System.Guid>)(result.GetParameterValue(1)));
			activityId = ((System.Nullable<int>)(result.GetParameterValue(2)));
			instanceId = ((System.Nullable<long>)(result.GetParameterValue(3)));
			keyValue = ((System.Nullable<long>)(result.GetParameterValue(4)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.ActivityModelCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_ActivityModelCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessRevisionId", DbType="Int")] System.Nullable<int> processRevisionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ReplacementId", DbType="Int")] System.Nullable<int> replacementId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityName", DbType="VarChar(50)")] string activityName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityTypeId", DbType="TinyInt")] System.Nullable<byte> activityTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubProcessGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> subProcessGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Startable", DbType="Bit")] System.Nullable<bool> startable, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Priority", DbType="TinyInt")] System.Nullable<byte> priority, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DocWait", DbType="Bit")] System.Nullable<bool> docWait, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IsLocationAware", DbType="Bit")] System.Nullable<bool> isLocationAware)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processRevisionId, replacementId, activityGuid, activityName, activityTypeId, subProcessGuid, startable, priority, docWait, isLocationAware);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.ActivityModelReplacementUpd")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_ActivityModelReplacementUpd([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> processGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> activityGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NewActivityGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> newActivityGuid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processGuid, activityGuid, newActivityGuid);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.CostTypeCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_CostTypeCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CostTypeId", DbType="Int")] ref System.Nullable<int> costTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CostType", DbType="VarChar(30)")] string costType)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), costTypeId, costType);
			costTypeId = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.CostTypeDelete")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_CostTypeDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CostTypeId", DbType="Int")] System.Nullable<int> costTypeId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), costTypeId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.CostTypeModify")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_CostTypeModify([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CostTypeId", DbType="Int")] System.Nullable<int> costTypeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CostType", DbType="VarChar(30)")] string costType)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), costTypeId, costType);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.FlowModelCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_FlowModelCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FlowGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> flowGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessRevisionId", DbType="Int")] System.Nullable<int> processRevisionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FromActivityModelId", DbType="Int")] System.Nullable<int> fromActivityModelId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Outcome", DbType="VarChar(30)")] string outcome, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ToActivityModelId", DbType="Int")] System.Nullable<int> toActivityModelId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OptimalFlow", DbType="Bit")] System.Nullable<bool> optimalFlow, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NegativeFlow", DbType="Bit")] System.Nullable<bool> negativeFlow, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Storyline", DbType="VarChar(200)")] string storyline)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), flowGuid, processRevisionId, fromActivityModelId, outcome, toActivityModelId, optimalFlow, negativeFlow, storyline);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.ProcessModelCreate")]
		public ISingleResult<Cloudcoremodel_ProcessModelCreateResult> Cloudcoremodel_ProcessModelCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> processGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessName", DbType="VarChar(50)")] string processName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processGuid, processName);
			return ((ISingleResult<Cloudcoremodel_ProcessModelCreateResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.ProcessModelDeploy")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_ProcessModelDeploy([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] System.Nullable<System.Guid> processGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SystemModuleId", DbType="Int")] System.Nullable<int> systemModuleId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processGuid, systemModuleId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.ProcessRevisionCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_ProcessRevisionCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessModelId", DbType="Int")] System.Nullable<int> processModelId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CheckSum", DbType="VarChar(MAX)")] string checkSum, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Changed", DbType="DateTime")] System.Nullable<System.DateTime> changed)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processModelId, checkSum, userId, changed);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.RevisionUpdate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_RevisionUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessGuid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> processGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CheckSum", DbType="VarChar(MAX)")] string checkSum, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processGuid, checkSum, userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="cloudcoremodel.SubProcessCreate")]
		[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")]
		public int Cloudcoremodel_SubProcessCreate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProcessRevisionId", DbType="Int")] System.Nullable<int> processRevisionId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Guid", DbType="UniqueIdentifier")] System.Nullable<System.Guid> guid, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="SubProcessName", DbType="VarChar(200)")] string subProcessName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), processRevisionId, guid, subProcessName);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.AccessPool")]
	public partial class Cloudcore_AccessPool : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AccessPoolId;
		
		private string _AccessPoolName;
		
		private int _ManagerId;
		
		private EntitySet<Cloudcore_AccessPoolUser> _Cloudcore_AccessPoolUser;
		
		private EntitySet<Cloudcore_ActivityAllocation> _Cloudcore_ActivityAllocation;
		
		private EntitySet<Cloudcore_DashboardRight> _Cloudcore_DashboardRight;
		
		private EntitySet<Cloudcore_SystemActionAllocation> _Cloudcore_SystemActionAllocation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccessPoolIdChanging(int value);
    partial void OnAccessPoolIdChanged();
    partial void OnAccessPoolNameChanging(string value);
    partial void OnAccessPoolNameChanged();
    partial void OnManagerIdChanging(int value);
    partial void OnManagerIdChanged();
    #endregion
		
		public Cloudcore_AccessPool()
		{
			this._Cloudcore_AccessPoolUser = new EntitySet<Cloudcore_AccessPoolUser>(new Action<Cloudcore_AccessPoolUser>(this.attach_Cloudcore_AccessPoolUser), new Action<Cloudcore_AccessPoolUser>(this.detach_Cloudcore_AccessPoolUser));
			this._Cloudcore_ActivityAllocation = new EntitySet<Cloudcore_ActivityAllocation>(new Action<Cloudcore_ActivityAllocation>(this.attach_Cloudcore_ActivityAllocation), new Action<Cloudcore_ActivityAllocation>(this.detach_Cloudcore_ActivityAllocation));
			this._Cloudcore_DashboardRight = new EntitySet<Cloudcore_DashboardRight>(new Action<Cloudcore_DashboardRight>(this.attach_Cloudcore_DashboardRight), new Action<Cloudcore_DashboardRight>(this.detach_Cloudcore_DashboardRight));
			this._Cloudcore_SystemActionAllocation = new EntitySet<Cloudcore_SystemActionAllocation>(new Action<Cloudcore_SystemActionAllocation>(this.attach_Cloudcore_SystemActionAllocation), new Action<Cloudcore_SystemActionAllocation>(this.detach_Cloudcore_SystemActionAllocation));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					this.OnAccessPoolIdChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolId = value;
					this.SendPropertyChanged("AccessPoolId");
					this.OnAccessPoolIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AccessPoolName
		{
			get
			{
				return this._AccessPoolName;
			}
			set
			{
				if ((this._AccessPoolName != value))
				{
					this.OnAccessPoolNameChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolName = value;
					this.SendPropertyChanged("AccessPoolName");
					this.OnAccessPoolNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					this.OnManagerIdChanging(value);
					this.SendPropertyChanging();
					this._ManagerId = value;
					this.SendPropertyChanged("ManagerId");
					this.OnManagerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AccessPoolUser_AccessPool", Storage="_Cloudcore_AccessPoolUser", ThisKey="AccessPoolId", OtherKey="AccessPoolId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_AccessPoolUser> Cloudcore_AccessPoolUser
		{
			get
			{
				return this._Cloudcore_AccessPoolUser;
			}
			set
			{
				this._Cloudcore_AccessPoolUser.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityAllocation_AccessPool", Storage="_Cloudcore_ActivityAllocation", ThisKey="AccessPoolId", OtherKey="AccessPoolId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityAllocation> Cloudcore_ActivityAllocation
		{
			get
			{
				return this._Cloudcore_ActivityAllocation;
			}
			set
			{
				this._Cloudcore_ActivityAllocation.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardRight_AccessRight", Storage="_Cloudcore_DashboardRight", ThisKey="AccessPoolId", OtherKey="AccessPoolId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_DashboardRight> Cloudcore_DashboardRight
		{
			get
			{
				return this._Cloudcore_DashboardRight;
			}
			set
			{
				this._Cloudcore_DashboardRight.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemActionAllocation_AccessRight", Storage="_Cloudcore_SystemActionAllocation", ThisKey="AccessPoolId", OtherKey="AccessPoolId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemActionAllocation> Cloudcore_SystemActionAllocation
		{
			get
			{
				return this._Cloudcore_SystemActionAllocation;
			}
			set
			{
				this._Cloudcore_SystemActionAllocation.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_AccessPoolUser(Cloudcore_AccessPoolUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = this;
		}
		
		private void detach_Cloudcore_AccessPoolUser(Cloudcore_AccessPoolUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = null;
		}
		
		private void attach_Cloudcore_ActivityAllocation(Cloudcore_ActivityAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = this;
		}
		
		private void detach_Cloudcore_ActivityAllocation(Cloudcore_ActivityAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = null;
		}
		
		private void attach_Cloudcore_DashboardRight(Cloudcore_DashboardRight entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = this;
		}
		
		private void detach_Cloudcore_DashboardRight(Cloudcore_DashboardRight entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = null;
		}
		
		private void attach_Cloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = this;
		}
		
		private void detach_Cloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_AccessPool = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.AccessPoolUser")]
	public partial class Cloudcore_AccessPoolUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AccessPoolId;
		
		private int _UserId;
		
		private EntityRef<Cloudcore_AccessPool> _Cloudcore_AccessPool;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccessPoolIdChanging(int value);
    partial void OnAccessPoolIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    #endregion
		
		public Cloudcore_AccessPoolUser()
		{
			this._Cloudcore_AccessPool = default(EntityRef<Cloudcore_AccessPool>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					if (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAccessPoolIdChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolId = value;
					this.SendPropertyChanged("AccessPoolId");
					this.OnAccessPoolIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AccessPoolUser_AccessPool", Storage="_Cloudcore_AccessPool", ThisKey="AccessPoolId", OtherKey="AccessPoolId", IsForeignKey=true)]
		public Cloudcore_AccessPool Cloudcore_AccessPool
		{
			get
			{
				return this._Cloudcore_AccessPool.Entity;
			}
			set
			{
				Cloudcore_AccessPool previousValue = this._Cloudcore_AccessPool.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_AccessPool.Entity = null;
						previousValue.Cloudcore_AccessPoolUser.Remove(this);
					}
					this._Cloudcore_AccessPool.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_AccessPoolUser.Add(this);
						this._AccessPoolId = value.AccessPoolId;
					}
					else
					{
						this._AccessPoolId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_AccessPool");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AccessPoolUser_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_AccessPoolUser.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_AccessPoolUser.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Activity")]
	public partial class Cloudcore_Activity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActivityId;
		
		private int _ActivityModelId;
		
		private int _ProcessRevisionId;
		
		private int _SystemModuleId;
		
		private byte _ActivityTypeId;
		
		private bool _IsLocationAware;
		
		private System.Guid _ActivityGuid;
		
		private System.Guid _SubProcessGuid;
		
		private System.Guid _ProcessGuid;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcoremodel_ActivityType> _Cloudcoremodel_ActivityType;
		
		private EntityRef<Cloudcore_SystemModule> _Cloudcore_SystemModule;
		
		private EntitySet<Cloudcore_ActivityAllocation> _Cloudcore_ActivityAllocation;
		
		private EntitySet<Cloudcore_WorklistFailure> _Cloudcore_WorklistFailure;
		
		private EntitySet<Cloudcore_CampaignItem> _Cloudcore_CampaignItem;
		
		private EntitySet<Cloudcore_SystemApplicationAllocation> _Cloudcore_SystemApplicationAllocation;
		
		private EntitySet<Cloudcore_Worklist> _Cloudcore_Worklist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    partial void OnActivityModelIdChanging(int value);
    partial void OnActivityModelIdChanged();
    partial void OnProcessRevisionIdChanging(int value);
    partial void OnProcessRevisionIdChanged();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    partial void OnActivityTypeIdChanging(byte value);
    partial void OnActivityTypeIdChanged();
    partial void OnIsLocationAwareChanging(bool value);
    partial void OnIsLocationAwareChanged();
    partial void OnActivityGuidChanging(System.Guid value);
    partial void OnActivityGuidChanged();
    partial void OnSubProcessGuidChanging(System.Guid value);
    partial void OnSubProcessGuidChanged();
    partial void OnProcessGuidChanging(System.Guid value);
    partial void OnProcessGuidChanged();
    #endregion
		
		public Cloudcore_Activity()
		{
			this._Cloudcoremodel_ActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._Cloudcoremodel_ActivityType = default(EntityRef<Cloudcoremodel_ActivityType>);
			this._Cloudcore_SystemModule = default(EntityRef<Cloudcore_SystemModule>);
			this._Cloudcore_ActivityAllocation = new EntitySet<Cloudcore_ActivityAllocation>(new Action<Cloudcore_ActivityAllocation>(this.attach_Cloudcore_ActivityAllocation), new Action<Cloudcore_ActivityAllocation>(this.detach_Cloudcore_ActivityAllocation));
			this._Cloudcore_WorklistFailure = new EntitySet<Cloudcore_WorklistFailure>(new Action<Cloudcore_WorklistFailure>(this.attach_Cloudcore_WorklistFailure), new Action<Cloudcore_WorklistFailure>(this.detach_Cloudcore_WorklistFailure));
			this._Cloudcore_CampaignItem = new EntitySet<Cloudcore_CampaignItem>(new Action<Cloudcore_CampaignItem>(this.attach_Cloudcore_CampaignItem), new Action<Cloudcore_CampaignItem>(this.detach_Cloudcore_CampaignItem));
			this._Cloudcore_SystemApplicationAllocation = new EntitySet<Cloudcore_SystemApplicationAllocation>(new Action<Cloudcore_SystemApplicationAllocation>(this.attach_Cloudcore_SystemApplicationAllocation), new Action<Cloudcore_SystemApplicationAllocation>(this.detach_Cloudcore_SystemApplicationAllocation));
			this._Cloudcore_Worklist = new EntitySet<Cloudcore_Worklist>(new Action<Cloudcore_Worklist>(this.attach_Cloudcore_Worklist), new Action<Cloudcore_Worklist>(this.detach_Cloudcore_Worklist));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					if (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityModelId = value;
					this.SendPropertyChanged("ActivityModelId");
					this.OnActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this.OnProcessRevisionIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevisionId = value;
					this.SendPropertyChanged("ProcessRevisionId");
					this.OnProcessRevisionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					if (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					if (this._Cloudcoremodel_ActivityType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityTypeId = value;
					this.SendPropertyChanged("ActivityTypeId");
					this.OnActivityTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsLocationAware", DbType="Bit NOT NULL")]
		public bool IsLocationAware
		{
			get
			{
				return this._IsLocationAware;
			}
			set
			{
				if ((this._IsLocationAware != value))
				{
					this.OnIsLocationAwareChanging(value);
					this.SendPropertyChanging();
					this._IsLocationAware = value;
					this.SendPropertyChanged("IsLocationAware");
					this.OnIsLocationAwareChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this.OnActivityGuidChanging(value);
					this.SendPropertyChanging();
					this._ActivityGuid = value;
					this.SendPropertyChanged("ActivityGuid");
					this.OnActivityGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this.OnSubProcessGuidChanging(value);
					this.SendPropertyChanging();
					this._SubProcessGuid = value;
					this.SendPropertyChanged("SubProcessGuid");
					this.OnSubProcessGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this.OnProcessGuidChanging(value);
					this.SendPropertyChanging();
					this._ProcessGuid = value;
					this.SendPropertyChanged("ProcessGuid");
					this.OnProcessGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_ActivityModel", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Cloudcoremodel_ActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityModel.Entity = null;
						previousValue.Cloudcore_Activity = null;
					}
					this._Cloudcoremodel_ActivityModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Activity = this;
						this._ActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._ActivityModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_ActivityType", Storage="_Cloudcoremodel_ActivityType", ThisKey="ActivityTypeId", OtherKey="ActivityTypeId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityType Cloudcoremodel_ActivityType
		{
			get
			{
				return this._Cloudcoremodel_ActivityType.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityType previousValue = this._Cloudcoremodel_ActivityType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityType.Entity = null;
						previousValue.Cloudcore_Activity.Remove(this);
					}
					this._Cloudcoremodel_ActivityType.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Activity.Add(this);
						this._ActivityTypeId = value.ActivityTypeId;
					}
					else
					{
						this._ActivityTypeId = default(byte);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_SystemModule", Storage="_Cloudcore_SystemModule", ThisKey="SystemModuleId", OtherKey="SystemModuleId", IsForeignKey=true)]
		public Cloudcore_SystemModule Cloudcore_SystemModule
		{
			get
			{
				return this._Cloudcore_SystemModule.Entity;
			}
			set
			{
				Cloudcore_SystemModule previousValue = this._Cloudcore_SystemModule.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemModule.Entity = null;
						previousValue.Cloudcore_Activity.Remove(this);
					}
					this._Cloudcore_SystemModule.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Activity.Add(this);
						this._SystemModuleId = value.SystemModuleId;
					}
					else
					{
						this._SystemModuleId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemModule");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityAllocation_Activity", Storage="_Cloudcore_ActivityAllocation", ThisKey="ActivityId", OtherKey="ActivityId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityAllocation> Cloudcore_ActivityAllocation
		{
			get
			{
				return this._Cloudcore_ActivityAllocation;
			}
			set
			{
				this._Cloudcore_ActivityAllocation.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailed_Activity", Storage="_Cloudcore_WorklistFailure", ThisKey="ActivityId", OtherKey="ActivityId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_WorklistFailure> Cloudcore_WorklistFailure
		{
			get
			{
				return this._Cloudcore_WorklistFailure;
			}
			set
			{
				this._Cloudcore_WorklistFailure.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Activity", Storage="_Cloudcore_CampaignItem", ThisKey="ActivityId", OtherKey="ActivityId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignItem> Cloudcore_CampaignItem
		{
			get
			{
				return this._Cloudcore_CampaignItem;
			}
			set
			{
				this._Cloudcore_CampaignItem.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemApplicationAllocation_Activity", Storage="_Cloudcore_SystemApplicationAllocation", ThisKey="ActivityId", OtherKey="ActivityId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemApplicationAllocation> Cloudcore_SystemApplicationAllocation
		{
			get
			{
				return this._Cloudcore_SystemApplicationAllocation;
			}
			set
			{
				this._Cloudcore_SystemApplicationAllocation.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_Activity", Storage="_Cloudcore_Worklist", ThisKey="ActivityId", OtherKey="ActivityId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Worklist> Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist;
			}
			set
			{
				this._Cloudcore_Worklist.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ActivityAllocation(Cloudcore_ActivityAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = this;
		}
		
		private void detach_Cloudcore_ActivityAllocation(Cloudcore_ActivityAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = null;
		}
		
		private void attach_Cloudcore_WorklistFailure(Cloudcore_WorklistFailure entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = this;
		}
		
		private void detach_Cloudcore_WorklistFailure(Cloudcore_WorklistFailure entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = null;
		}
		
		private void attach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = this;
		}
		
		private void detach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = null;
		}
		
		private void attach_Cloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = this;
		}
		
		private void detach_Cloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = null;
		}
		
		private void attach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = this;
		}
		
		private void detach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Activity = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ActivityAllocation")]
	public partial class Cloudcore_ActivityAllocation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActivityId;
		
		private int _AccessPoolId;
		
		private EntityRef<Cloudcore_AccessPool> _Cloudcore_AccessPool;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    partial void OnAccessPoolIdChanging(int value);
    partial void OnAccessPoolIdChanged();
    #endregion
		
		public Cloudcore_ActivityAllocation()
		{
			this._Cloudcore_AccessPool = default(EntityRef<Cloudcore_AccessPool>);
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					if (this._Cloudcore_Activity.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					if (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAccessPoolIdChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolId = value;
					this.SendPropertyChanged("AccessPoolId");
					this.OnAccessPoolIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityAllocation_AccessPool", Storage="_Cloudcore_AccessPool", ThisKey="AccessPoolId", OtherKey="AccessPoolId", IsForeignKey=true)]
		public Cloudcore_AccessPool Cloudcore_AccessPool
		{
			get
			{
				return this._Cloudcore_AccessPool.Entity;
			}
			set
			{
				Cloudcore_AccessPool previousValue = this._Cloudcore_AccessPool.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_AccessPool.Entity = null;
						previousValue.Cloudcore_ActivityAllocation.Remove(this);
					}
					this._Cloudcore_AccessPool.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityAllocation.Add(this);
						this._AccessPoolId = value.AccessPoolId;
					}
					else
					{
						this._AccessPoolId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_AccessPool");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityAllocation_Activity", Storage="_Cloudcore_Activity", ThisKey="ActivityId", OtherKey="ActivityId", IsForeignKey=true)]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcore_ActivityAllocation.Remove(this);
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityAllocation.Add(this);
						this._ActivityId = value.ActivityId;
					}
					else
					{
						this._ActivityId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ActivityFailureHistory")]
	public partial class Cloudcore_ActivityFailureHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ArchiveFailureId;
		
		private int _ActivityModelId;
		
		private System.DateTime _FailedAt;
		
		private int _UserId;
		
		private string _Reason;
		
		private long _KeyValue;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnArchiveFailureIdChanging(int value);
    partial void OnArchiveFailureIdChanged();
    partial void OnActivityModelIdChanging(int value);
    partial void OnActivityModelIdChanged();
    partial void OnFailedAtChanging(System.DateTime value);
    partial void OnFailedAtChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    partial void OnKeyValueChanging(long value);
    partial void OnKeyValueChanged();
    #endregion
		
		public Cloudcore_ActivityFailureHistory()
		{
			this._Cloudcoremodel_ActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArchiveFailureId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ArchiveFailureId
		{
			get
			{
				return this._ArchiveFailureId;
			}
			set
			{
				if ((this._ArchiveFailureId != value))
				{
					this.OnArchiveFailureIdChanging(value);
					this.SendPropertyChanging();
					this._ArchiveFailureId = value;
					this.SendPropertyChanged("ArchiveFailureId");
					this.OnArchiveFailureIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					if (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityModelId = value;
					this.SendPropertyChanged("ActivityModelId");
					this.OnActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FailedAt", DbType="DateTime NOT NULL")]
		public System.DateTime FailedAt
		{
			get
			{
				return this._FailedAt;
			}
			set
			{
				if ((this._FailedAt != value))
				{
					this.OnFailedAtChanging(value);
					this.SendPropertyChanging();
					this._FailedAt = value;
					this.SendPropertyChanged("FailedAt");
					this.OnFailedAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this.OnReasonChanging(value);
					this.SendPropertyChanging();
					this._Reason = value;
					this.SendPropertyChanged("Reason");
					this.OnReasonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this.OnKeyValueChanging(value);
					this.SendPropertyChanging();
					this._KeyValue = value;
					this.SendPropertyChanged("KeyValue");
					this.OnKeyValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailureHistory_ActivityModel", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Cloudcoremodel_ActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityModel.Entity = null;
						previousValue.Cloudcore_ActivityFailureHistory.Remove(this);
					}
					this._Cloudcoremodel_ActivityModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityFailureHistory.Add(this);
						this._ActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._ActivityModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailureHistory_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_ActivityFailureHistory.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityFailureHistory.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ActivityHistory")]
	public partial class Cloudcore_ActivityHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ActivityArchiveId;
		
		private int _ActivityModelId;
		
		private int _FlowModelId;
		
		private long _InstanceId;
		
		private long _PInstanceId;
		
		private System.DateTime _Assigned;
		
		private System.DateTime _Activate;
		
		private System.DateTime _Opened;
		
		private System.DateTime _Completed;
		
		private byte _Priority;
		
		private byte _StatusTypeId;
		
		private int _UserId;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcoremodel_StatusType> _Cloudcoremodel_StatusType;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivityArchiveIdChanging(long value);
    partial void OnActivityArchiveIdChanged();
    partial void OnActivityModelIdChanging(int value);
    partial void OnActivityModelIdChanged();
    partial void OnFlowModelIdChanging(int value);
    partial void OnFlowModelIdChanged();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnPInstanceIdChanging(long value);
    partial void OnPInstanceIdChanged();
    partial void OnAssignedChanging(System.DateTime value);
    partial void OnAssignedChanged();
    partial void OnActivateChanging(System.DateTime value);
    partial void OnActivateChanged();
    partial void OnOpenedChanging(System.DateTime value);
    partial void OnOpenedChanged();
    partial void OnCompletedChanging(System.DateTime value);
    partial void OnCompletedChanged();
    partial void OnPriorityChanging(byte value);
    partial void OnPriorityChanged();
    partial void OnStatusTypeIdChanging(byte value);
    partial void OnStatusTypeIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    #endregion
		
		public Cloudcore_ActivityHistory()
		{
			this._Cloudcoremodel_ActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._Cloudcoremodel_StatusType = default(EntityRef<Cloudcoremodel_StatusType>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityArchiveId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ActivityArchiveId
		{
			get
			{
				return this._ActivityArchiveId;
			}
			set
			{
				if ((this._ActivityArchiveId != value))
				{
					this.OnActivityArchiveIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityArchiveId = value;
					this.SendPropertyChanged("ActivityArchiveId");
					this.OnActivityArchiveIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					if (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityModelId = value;
					this.SendPropertyChanged("ActivityModelId");
					this.OnActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowModelId", DbType="Int NOT NULL")]
		public int FlowModelId
		{
			get
			{
				return this._FlowModelId;
			}
			set
			{
				if ((this._FlowModelId != value))
				{
					this.OnFlowModelIdChanging(value);
					this.SendPropertyChanging();
					this._FlowModelId = value;
					this.SendPropertyChanged("FlowModelId");
					this.OnFlowModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PInstanceId", DbType="BigInt NOT NULL")]
		public long PInstanceId
		{
			get
			{
				return this._PInstanceId;
			}
			set
			{
				if ((this._PInstanceId != value))
				{
					this.OnPInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._PInstanceId = value;
					this.SendPropertyChanged("PInstanceId");
					this.OnPInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assigned", DbType="DateTime NOT NULL")]
		public System.DateTime Assigned
		{
			get
			{
				return this._Assigned;
			}
			set
			{
				if ((this._Assigned != value))
				{
					this.OnAssignedChanging(value);
					this.SendPropertyChanging();
					this._Assigned = value;
					this.SendPropertyChanged("Assigned");
					this.OnAssignedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this.OnActivateChanging(value);
					this.SendPropertyChanging();
					this._Activate = value;
					this.SendPropertyChanged("Activate");
					this.OnActivateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opened", DbType="DateTime NOT NULL")]
		public System.DateTime Opened
		{
			get
			{
				return this._Opened;
			}
			set
			{
				if ((this._Opened != value))
				{
					this.OnOpenedChanging(value);
					this.SendPropertyChanging();
					this._Opened = value;
					this.SendPropertyChanged("Opened");
					this.OnOpenedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Completed", DbType="DateTime NOT NULL")]
		public System.DateTime Completed
		{
			get
			{
				return this._Completed;
			}
			set
			{
				if ((this._Completed != value))
				{
					this.OnCompletedChanging(value);
					this.SendPropertyChanging();
					this._Completed = value;
					this.SendPropertyChanged("Completed");
					this.OnCompletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this.OnPriorityChanging(value);
					this.SendPropertyChanging();
					this._Priority = value;
					this.SendPropertyChanged("Priority");
					this.OnPriorityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					if (this._Cloudcoremodel_StatusType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStatusTypeIdChanging(value);
					this.SendPropertyChanging();
					this._StatusTypeId = value;
					this.SendPropertyChanged("StatusTypeId");
					this.OnStatusTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_ActivityModel", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Cloudcoremodel_ActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityModel.Entity = null;
						previousValue.Cloudcore_ActivityHistory.Remove(this);
					}
					this._Cloudcoremodel_ActivityModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityHistory.Add(this);
						this._ActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._ActivityModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_StatusType", Storage="_Cloudcoremodel_StatusType", ThisKey="StatusTypeId", OtherKey="StatusTypeId", IsForeignKey=true)]
		public Cloudcoremodel_StatusType Cloudcoremodel_StatusType
		{
			get
			{
				return this._Cloudcoremodel_StatusType.Entity;
			}
			set
			{
				Cloudcoremodel_StatusType previousValue = this._Cloudcoremodel_StatusType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_StatusType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_StatusType.Entity = null;
						previousValue.Cloudcore_ActivityHistory.Remove(this);
					}
					this._Cloudcoremodel_StatusType.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityHistory.Add(this);
						this._StatusTypeId = value.StatusTypeId;
					}
					else
					{
						this._StatusTypeId = default(byte);
					}
					this.SendPropertyChanged("Cloudcoremodel_StatusType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_ActivityHistory.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ActivityHistory.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.ActivityModel")]
	public partial class Cloudcoremodel_ActivityModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActivityModelId;
		
		private int _ProcessRevisionId;
		
		private int _ReplacementId;
		
		private System.Guid _ActivityGuid;
		
		private int _SubProcessId;
		
		private string _ActivityName;
		
		private byte _ActivityTypeId;
		
		private int _CostTypeId;
		
		private bool _Startable;
		
		private int _Priority;
		
		private bool _DocWait;
		
		private bool _IsLocationAware;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntitySet<Cloudcore_ActivityFailureHistory> _Cloudcore_ActivityFailureHistory;
		
		private EntitySet<Cloudcore_ActivityHistory> _Cloudcore_ActivityHistory;
		
		private EntitySet<Cloudcore_CostLedger> _Cloudcore_CostLedger;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Replacement;
		
		private EntitySet<Cloudcoremodel_ActivityModel> _ActivityModel;
		
		private EntityRef<Cloudcoremodel_ActivityType> _Cloudcoremodel_ActivityType;
		
		private EntityRef<Cloudcoremodel_CostType> _Cloudcoremodel_CostType;
		
		private EntityRef<Cloudcoremodel_ProcessRevision> _Cloudcoremodel_ProcessRevision;
		
		private EntityRef<Cloudcoremodel_SubProcess> _Cloudcoremodel_SubProcess;
		
		private EntitySet<Cloudcoremodel_FlowModel> _Cloudcoremodel_FlowModel;
		
		private EntitySet<Cloudcoremodel_FlowModel> _FlowModel_ActivityModel_To;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivityModelIdChanging(int value);
    partial void OnActivityModelIdChanged();
    partial void OnProcessRevisionIdChanging(int value);
    partial void OnProcessRevisionIdChanged();
    partial void OnReplacementIdChanging(int value);
    partial void OnReplacementIdChanged();
    partial void OnActivityGuidChanging(System.Guid value);
    partial void OnActivityGuidChanged();
    partial void OnSubProcessIdChanging(int value);
    partial void OnSubProcessIdChanged();
    partial void OnActivityNameChanging(string value);
    partial void OnActivityNameChanged();
    partial void OnActivityTypeIdChanging(byte value);
    partial void OnActivityTypeIdChanged();
    partial void OnCostTypeIdChanging(int value);
    partial void OnCostTypeIdChanged();
    partial void OnStartableChanging(bool value);
    partial void OnStartableChanged();
    partial void OnPriorityChanging(int value);
    partial void OnPriorityChanged();
    partial void OnDocWaitChanging(bool value);
    partial void OnDocWaitChanged();
    partial void OnIsLocationAwareChanging(bool value);
    partial void OnIsLocationAwareChanged();
    #endregion
		
		public Cloudcoremodel_ActivityModel()
		{
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			this._Cloudcore_ActivityFailureHistory = new EntitySet<Cloudcore_ActivityFailureHistory>(new Action<Cloudcore_ActivityFailureHistory>(this.attach_Cloudcore_ActivityFailureHistory), new Action<Cloudcore_ActivityFailureHistory>(this.detach_Cloudcore_ActivityFailureHistory));
			this._Cloudcore_ActivityHistory = new EntitySet<Cloudcore_ActivityHistory>(new Action<Cloudcore_ActivityHistory>(this.attach_Cloudcore_ActivityHistory), new Action<Cloudcore_ActivityHistory>(this.detach_Cloudcore_ActivityHistory));
			this._Cloudcore_CostLedger = new EntitySet<Cloudcore_CostLedger>(new Action<Cloudcore_CostLedger>(this.attach_Cloudcore_CostLedger), new Action<Cloudcore_CostLedger>(this.detach_Cloudcore_CostLedger));
			this._Replacement = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._ActivityModel = new EntitySet<Cloudcoremodel_ActivityModel>(new Action<Cloudcoremodel_ActivityModel>(this.attach_ActivityModel), new Action<Cloudcoremodel_ActivityModel>(this.detach_ActivityModel));
			this._Cloudcoremodel_ActivityType = default(EntityRef<Cloudcoremodel_ActivityType>);
			this._Cloudcoremodel_CostType = default(EntityRef<Cloudcoremodel_CostType>);
			this._Cloudcoremodel_ProcessRevision = default(EntityRef<Cloudcoremodel_ProcessRevision>);
			this._Cloudcoremodel_SubProcess = default(EntityRef<Cloudcoremodel_SubProcess>);
			this._Cloudcoremodel_FlowModel = new EntitySet<Cloudcoremodel_FlowModel>(new Action<Cloudcoremodel_FlowModel>(this.attach_Cloudcoremodel_FlowModel), new Action<Cloudcoremodel_FlowModel>(this.detach_Cloudcoremodel_FlowModel));
			this._FlowModel_ActivityModel_To = new EntitySet<Cloudcoremodel_FlowModel>(new Action<Cloudcoremodel_FlowModel>(this.attach_FlowModel_ActivityModel_To), new Action<Cloudcoremodel_FlowModel>(this.detach_FlowModel_ActivityModel_To));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this.OnActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityModelId = value;
					this.SendPropertyChanged("ActivityModelId");
					this.OnActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					if (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessRevisionIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevisionId = value;
					this.SendPropertyChanged("ProcessRevisionId");
					this.OnProcessRevisionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReplacementId", DbType="Int NOT NULL")]
		public int ReplacementId
		{
			get
			{
				return this._ReplacementId;
			}
			set
			{
				if ((this._ReplacementId != value))
				{
					if (this._Replacement.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnReplacementIdChanging(value);
					this.SendPropertyChanging();
					this._ReplacementId = value;
					this.SendPropertyChanged("ReplacementId");
					this.OnReplacementIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this.OnActivityGuidChanging(value);
					this.SendPropertyChanging();
					this._ActivityGuid = value;
					this.SendPropertyChanged("ActivityGuid");
					this.OnActivityGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					if (this._Cloudcoremodel_SubProcess.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSubProcessIdChanging(value);
					this.SendPropertyChanging();
					this._SubProcessId = value;
					this.SendPropertyChanged("SubProcessId");
					this.OnSubProcessIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this.OnActivityNameChanging(value);
					this.SendPropertyChanging();
					this._ActivityName = value;
					this.SendPropertyChanged("ActivityName");
					this.OnActivityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					if (this._Cloudcoremodel_ActivityType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityTypeId = value;
					this.SendPropertyChanged("ActivityTypeId");
					this.OnActivityTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CostTypeId", DbType="Int NOT NULL")]
		public int CostTypeId
		{
			get
			{
				return this._CostTypeId;
			}
			set
			{
				if ((this._CostTypeId != value))
				{
					if (this._Cloudcoremodel_CostType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCostTypeIdChanging(value);
					this.SendPropertyChanging();
					this._CostTypeId = value;
					this.SendPropertyChanged("CostTypeId");
					this.OnCostTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Startable", DbType="Bit NOT NULL")]
		public bool Startable
		{
			get
			{
				return this._Startable;
			}
			set
			{
				if ((this._Startable != value))
				{
					this.OnStartableChanging(value);
					this.SendPropertyChanging();
					this._Startable = value;
					this.SendPropertyChanged("Startable");
					this.OnStartableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="Int NOT NULL")]
		public int Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this.OnPriorityChanging(value);
					this.SendPropertyChanging();
					this._Priority = value;
					this.SendPropertyChanged("Priority");
					this.OnPriorityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this.OnDocWaitChanging(value);
					this.SendPropertyChanging();
					this._DocWait = value;
					this.SendPropertyChanged("DocWait");
					this.OnDocWaitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsLocationAware", DbType="Bit NOT NULL")]
		public bool IsLocationAware
		{
			get
			{
				return this._IsLocationAware;
			}
			set
			{
				if ((this._IsLocationAware != value))
				{
					this.OnIsLocationAwareChanging(value);
					this.SendPropertyChanging();
					this._IsLocationAware = value;
					this.SendPropertyChanged("IsLocationAware");
					this.OnIsLocationAwareChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_ActivityModel", Storage="_Cloudcore_Activity", ThisKey="ActivityModelId", OtherKey="ActivityModelId", IsUnique=true, IsForeignKey=false, DeleteRule="NO ACTION")]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcoremodel_ActivityModel = null;
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ActivityModel = this;
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailureHistory_ActivityModel", Storage="_Cloudcore_ActivityFailureHistory", ThisKey="ActivityModelId", OtherKey="ActivityModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityFailureHistory> Cloudcore_ActivityFailureHistory
		{
			get
			{
				return this._Cloudcore_ActivityFailureHistory;
			}
			set
			{
				this._Cloudcore_ActivityFailureHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_ActivityModel", Storage="_Cloudcore_ActivityHistory", ThisKey="ActivityModelId", OtherKey="ActivityModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityHistory> Cloudcore_ActivityHistory
		{
			get
			{
				return this._Cloudcore_ActivityHistory;
			}
			set
			{
				this._Cloudcore_ActivityHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CostLedger_ActivityModel", Storage="_Cloudcore_CostLedger", ThisKey="ActivityModelId", OtherKey="ActivityModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CostLedger> Cloudcore_CostLedger
		{
			get
			{
				return this._Cloudcore_CostLedger;
			}
			set
			{
				this._Cloudcore_CostLedger.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ActivityModel_Replacement", Storage="_Replacement", ThisKey="ReplacementId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Replacement
		{
			get
			{
				return this._Replacement.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Replacement.Entity;
				if (((previousValue != value) 
							|| (this._Replacement.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Replacement.Entity = null;
						previousValue.ActivityModel.Remove(this);
					}
					this._Replacement.Entity = value;
					if ((value != null))
					{
						value.ActivityModel.Add(this);
						this._ReplacementId = value.ActivityModelId;
					}
					else
					{
						this._ReplacementId = default(int);
					}
					this.SendPropertyChanged("Replacement");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ActivityModel_Replacement", Storage="_ActivityModel", ThisKey="ActivityModelId", OtherKey="ReplacementId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ActivityModel> ActivityModel
		{
			get
			{
				return this._ActivityModel;
			}
			set
			{
				this._ActivityModel.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ActivityType", Storage="_Cloudcoremodel_ActivityType", ThisKey="ActivityTypeId", OtherKey="ActivityTypeId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityType Cloudcoremodel_ActivityType
		{
			get
			{
				return this._Cloudcoremodel_ActivityType.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityType previousValue = this._Cloudcoremodel_ActivityType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityType.Entity = null;
						previousValue.Cloudcoremodel_ActivityModel.Remove(this);
					}
					this._Cloudcoremodel_ActivityType.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ActivityModel.Add(this);
						this._ActivityTypeId = value.ActivityTypeId;
					}
					else
					{
						this._ActivityTypeId = default(byte);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_CostType", Storage="_Cloudcoremodel_CostType", ThisKey="CostTypeId", OtherKey="CostTypeId", IsForeignKey=true)]
		public Cloudcoremodel_CostType Cloudcoremodel_CostType
		{
			get
			{
				return this._Cloudcoremodel_CostType.Entity;
			}
			set
			{
				Cloudcoremodel_CostType previousValue = this._Cloudcoremodel_CostType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_CostType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_CostType.Entity = null;
						previousValue.Cloudcoremodel_ActivityModel.Remove(this);
					}
					this._Cloudcoremodel_CostType.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ActivityModel.Add(this);
						this._CostTypeId = value.CostTypeId;
					}
					else
					{
						this._CostTypeId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_CostType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ProcessRevision", Storage="_Cloudcoremodel_ProcessRevision", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", IsForeignKey=true)]
		public Cloudcoremodel_ProcessRevision Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this._Cloudcoremodel_ProcessRevision.Entity;
			}
			set
			{
				Cloudcoremodel_ProcessRevision previousValue = this._Cloudcoremodel_ProcessRevision.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ProcessRevision.Entity = null;
						previousValue.Cloudcoremodel_ActivityModel.Remove(this);
					}
					this._Cloudcoremodel_ProcessRevision.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ActivityModel.Add(this);
						this._ProcessRevisionId = value.ProcessRevisionId;
					}
					else
					{
						this._ProcessRevisionId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ProcessRevision");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_SubProcess", Storage="_Cloudcoremodel_SubProcess", ThisKey="SubProcessId", OtherKey="SubProcessId", IsForeignKey=true)]
		public Cloudcoremodel_SubProcess Cloudcoremodel_SubProcess
		{
			get
			{
				return this._Cloudcoremodel_SubProcess.Entity;
			}
			set
			{
				Cloudcoremodel_SubProcess previousValue = this._Cloudcoremodel_SubProcess.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_SubProcess.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_SubProcess.Entity = null;
						previousValue.Cloudcoremodel_ActivityModel.Remove(this);
					}
					this._Cloudcoremodel_SubProcess.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ActivityModel.Add(this);
						this._SubProcessId = value.SubProcessId;
					}
					else
					{
						this._SubProcessId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_SubProcess");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ActivityModel_From", Storage="_Cloudcoremodel_FlowModel", ThisKey="ActivityModelId", OtherKey="FromActivityModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_FlowModel> Cloudcoremodel_FlowModel
		{
			get
			{
				return this._Cloudcoremodel_FlowModel;
			}
			set
			{
				this._Cloudcoremodel_FlowModel.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ActivityModel_To", Storage="_FlowModel_ActivityModel_To", ThisKey="ActivityModelId", OtherKey="ToActivityModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_FlowModel> FlowModel_ActivityModel_To
		{
			get
			{
				return this._FlowModel_ActivityModel_To;
			}
			set
			{
				this._FlowModel_ActivityModel_To.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = this;
		}
		
		private void detach_Cloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = null;
		}
		
		private void attach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = this;
		}
		
		private void detach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = null;
		}
		
		private void attach_Cloudcore_CostLedger(Cloudcore_CostLedger entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = this;
		}
		
		private void detach_Cloudcore_CostLedger(Cloudcore_CostLedger entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = null;
		}
		
		private void attach_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Replacement = this;
		}
		
		private void detach_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Replacement = null;
		}
		
		private void attach_Cloudcoremodel_FlowModel(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = this;
		}
		
		private void detach_Cloudcoremodel_FlowModel(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityModel = null;
		}
		
		private void attach_FlowModel_ActivityModel_To(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.ToActivityModel = this;
		}
		
		private void detach_FlowModel_ActivityModel_To(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.ToActivityModel = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.ActivityType")]
	public partial class Cloudcoremodel_ActivityType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _ActivityTypeId;
		
		private string _ActivityTypeName;
		
		private EntitySet<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntitySet<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActivityTypeIdChanging(byte value);
    partial void OnActivityTypeIdChanged();
    partial void OnActivityTypeNameChanging(string value);
    partial void OnActivityTypeNameChanged();
    #endregion
		
		public Cloudcoremodel_ActivityType()
		{
			this._Cloudcore_Activity = new EntitySet<Cloudcore_Activity>(new Action<Cloudcore_Activity>(this.attach_Cloudcore_Activity), new Action<Cloudcore_Activity>(this.detach_Cloudcore_Activity));
			this._Cloudcoremodel_ActivityModel = new EntitySet<Cloudcoremodel_ActivityModel>(new Action<Cloudcoremodel_ActivityModel>(this.attach_Cloudcoremodel_ActivityModel), new Action<Cloudcoremodel_ActivityModel>(this.detach_Cloudcoremodel_ActivityModel));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL", IsPrimaryKey=true)]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this.OnActivityTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityTypeId = value;
					this.SendPropertyChanged("ActivityTypeId");
					this.OnActivityTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this.OnActivityTypeNameChanging(value);
					this.SendPropertyChanging();
					this._ActivityTypeName = value;
					this.SendPropertyChanged("ActivityTypeName");
					this.OnActivityTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_ActivityType", Storage="_Cloudcore_Activity", ThisKey="ActivityTypeId", OtherKey="ActivityTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Activity> Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity;
			}
			set
			{
				this._Cloudcore_Activity.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ActivityType", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ActivityTypeId", OtherKey="ActivityTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ActivityModel> Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel;
			}
			set
			{
				this._Cloudcoremodel_ActivityModel.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_Activity(Cloudcore_Activity entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityType = this;
		}
		
		private void detach_Cloudcore_Activity(Cloudcore_Activity entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityType = null;
		}
		
		private void attach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityType = this;
		}
		
		private void detach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ActivityType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Campaign")]
	public partial class Cloudcore_Campaign : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CampaignID;
		
		private string _CampaignName;
		
		private string _CampaignDesc;
		
		private int _ManagerId;
		
		private short _StatusID;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
		private EntitySet<Cloudcore_CampaignArchive> _Cloudcore_CampaignArchive;
		
		private EntitySet<Cloudcore_CampaignItem> _Cloudcore_CampaignItem;
		
		private EntitySet<Cloudcore_CampaignUser> _Cloudcore_CampaignUser;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCampaignIDChanging(int value);
    partial void OnCampaignIDChanged();
    partial void OnCampaignNameChanging(string value);
    partial void OnCampaignNameChanged();
    partial void OnCampaignDescChanging(string value);
    partial void OnCampaignDescChanged();
    partial void OnManagerIdChanging(int value);
    partial void OnManagerIdChanged();
    partial void OnStatusIDChanging(short value);
    partial void OnStatusIDChanged();
    #endregion
		
		public Cloudcore_Campaign()
		{
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			this._Cloudcore_CampaignArchive = new EntitySet<Cloudcore_CampaignArchive>(new Action<Cloudcore_CampaignArchive>(this.attach_Cloudcore_CampaignArchive), new Action<Cloudcore_CampaignArchive>(this.detach_Cloudcore_CampaignArchive));
			this._Cloudcore_CampaignItem = new EntitySet<Cloudcore_CampaignItem>(new Action<Cloudcore_CampaignItem>(this.attach_Cloudcore_CampaignItem), new Action<Cloudcore_CampaignItem>(this.detach_Cloudcore_CampaignItem));
			this._Cloudcore_CampaignUser = new EntitySet<Cloudcore_CampaignUser>(new Action<Cloudcore_CampaignUser>(this.attach_Cloudcore_CampaignUser), new Action<Cloudcore_CampaignUser>(this.detach_Cloudcore_CampaignUser));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this.OnCampaignIDChanging(value);
					this.SendPropertyChanging();
					this._CampaignID = value;
					this.SendPropertyChanged("CampaignID");
					this.OnCampaignIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CampaignName
		{
			get
			{
				return this._CampaignName;
			}
			set
			{
				if ((this._CampaignName != value))
				{
					this.OnCampaignNameChanging(value);
					this.SendPropertyChanging();
					this._CampaignName = value;
					this.SendPropertyChanged("CampaignName");
					this.OnCampaignNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignDesc", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string CampaignDesc
		{
			get
			{
				return this._CampaignDesc;
			}
			set
			{
				if ((this._CampaignDesc != value))
				{
					this.OnCampaignDescChanging(value);
					this.SendPropertyChanging();
					this._CampaignDesc = value;
					this.SendPropertyChanged("CampaignDesc");
					this.OnCampaignDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnManagerIdChanging(value);
					this.SendPropertyChanging();
					this._ManagerId = value;
					this.SendPropertyChanged("ManagerId");
					this.OnManagerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusID", DbType="SmallInt NOT NULL")]
		public short StatusID
		{
			get
			{
				return this._StatusID;
			}
			set
			{
				if ((this._StatusID != value))
				{
					this.OnStatusIDChanging(value);
					this.SendPropertyChanging();
					this._StatusID = value;
					this.SendPropertyChanged("StatusID");
					this.OnStatusIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Campaign_User", Storage="_Cloudcore_User", ThisKey="ManagerId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_Campaign.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Campaign.Add(this);
						this._ManagerId = value.UserId;
					}
					else
					{
						this._ManagerId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignArchive_Campaign", Storage="_Cloudcore_CampaignArchive", ThisKey="CampaignID", OtherKey="CampaignID", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignArchive> Cloudcore_CampaignArchive
		{
			get
			{
				return this._Cloudcore_CampaignArchive;
			}
			set
			{
				this._Cloudcore_CampaignArchive.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Campaign", Storage="_Cloudcore_CampaignItem", ThisKey="CampaignID", OtherKey="CampaignID", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignItem> Cloudcore_CampaignItem
		{
			get
			{
				return this._Cloudcore_CampaignItem;
			}
			set
			{
				this._Cloudcore_CampaignItem.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignUser_Campaign", Storage="_Cloudcore_CampaignUser", ThisKey="CampaignID", OtherKey="CampaignID", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignUser> Cloudcore_CampaignUser
		{
			get
			{
				return this._Cloudcore_CampaignUser;
			}
			set
			{
				this._Cloudcore_CampaignUser.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_CampaignArchive(Cloudcore_CampaignArchive entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = this;
		}
		
		private void detach_Cloudcore_CampaignArchive(Cloudcore_CampaignArchive entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = null;
		}
		
		private void attach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = this;
		}
		
		private void detach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = null;
		}
		
		private void attach_Cloudcore_CampaignUser(Cloudcore_CampaignUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = this;
		}
		
		private void detach_Cloudcore_CampaignUser(Cloudcore_CampaignUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Campaign = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.CampaignArchive")]
	public partial class Cloudcore_CampaignArchive : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CampaignID;
		
		private long _InstanceId;
		
		private int _UserId;
		
		private System.DateTime _Finished;
		
		private int _StatusID;
		
		private string _Status;
		
		private EntityRef<Cloudcore_Campaign> _Cloudcore_Campaign;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCampaignIDChanging(int value);
    partial void OnCampaignIDChanged();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnFinishedChanging(System.DateTime value);
    partial void OnFinishedChanged();
    partial void OnStatusIDChanging(int value);
    partial void OnStatusIDChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    #endregion
		
		public Cloudcore_CampaignArchive()
		{
			this._Cloudcore_Campaign = default(EntityRef<Cloudcore_Campaign>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					if (this._Cloudcore_Campaign.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCampaignIDChanging(value);
					this.SendPropertyChanging();
					this._CampaignID = value;
					this.SendPropertyChanged("CampaignID");
					this.OnCampaignIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finished", DbType="DateTime NOT NULL")]
		public System.DateTime Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				if ((this._Finished != value))
				{
					this.OnFinishedChanging(value);
					this.SendPropertyChanging();
					this._Finished = value;
					this.SendPropertyChanged("Finished");
					this.OnFinishedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusID", DbType="Int NOT NULL")]
		public int StatusID
		{
			get
			{
				return this._StatusID;
			}
			set
			{
				if ((this._StatusID != value))
				{
					this.OnStatusIDChanging(value);
					this.SendPropertyChanging();
					this._StatusID = value;
					this.SendPropertyChanged("StatusID");
					this.OnStatusIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", AutoSync=AutoSync.Always, DbType="VarChar(11) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [StatusID] when (1) then \'Cancelled\' when (2) then \'Unavailable\' else \'Comp" +
			"leted\' end)")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignArchive_Campaign", Storage="_Cloudcore_Campaign", ThisKey="CampaignID", OtherKey="CampaignID", IsForeignKey=true)]
		public Cloudcore_Campaign Cloudcore_Campaign
		{
			get
			{
				return this._Cloudcore_Campaign.Entity;
			}
			set
			{
				Cloudcore_Campaign previousValue = this._Cloudcore_Campaign.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Campaign.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Campaign.Entity = null;
						previousValue.Cloudcore_CampaignArchive.Remove(this);
					}
					this._Cloudcore_Campaign.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignArchive.Add(this);
						this._CampaignID = value.CampaignID;
					}
					else
					{
						this._CampaignID = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Campaign");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignArchive_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_CampaignArchive.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignArchive.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.CampaignItem")]
	public partial class Cloudcore_CampaignItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CampaignID;
		
		private long _InstanceId;
		
		private int _ActivityId;
		
		private bool _Opened;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntityRef<Cloudcore_Campaign> _Cloudcore_Campaign;
		
		private EntityRef<Cloudcore_Worklist> _Cloudcore_Worklist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCampaignIDChanging(int value);
    partial void OnCampaignIDChanged();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    partial void OnOpenedChanging(bool value);
    partial void OnOpenedChanged();
    #endregion
		
		public Cloudcore_CampaignItem()
		{
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			this._Cloudcore_Campaign = default(EntityRef<Cloudcore_Campaign>);
			this._Cloudcore_Worklist = default(EntityRef<Cloudcore_Worklist>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					if (this._Cloudcore_Campaign.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCampaignIDChanging(value);
					this.SendPropertyChanging();
					this._CampaignID = value;
					this.SendPropertyChanged("CampaignID");
					this.OnCampaignIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					if (this._Cloudcore_Worklist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					if (this._Cloudcore_Activity.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opened", DbType="Bit NOT NULL")]
		public bool Opened
		{
			get
			{
				return this._Opened;
			}
			set
			{
				if ((this._Opened != value))
				{
					this.OnOpenedChanging(value);
					this.SendPropertyChanging();
					this._Opened = value;
					this.SendPropertyChanged("Opened");
					this.OnOpenedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Activity", Storage="_Cloudcore_Activity", ThisKey="ActivityId", OtherKey="ActivityId", IsForeignKey=true)]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcore_CampaignItem.Remove(this);
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignItem.Add(this);
						this._ActivityId = value.ActivityId;
					}
					else
					{
						this._ActivityId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Campaign", Storage="_Cloudcore_Campaign", ThisKey="CampaignID", OtherKey="CampaignID", IsForeignKey=true)]
		public Cloudcore_Campaign Cloudcore_Campaign
		{
			get
			{
				return this._Cloudcore_Campaign.Entity;
			}
			set
			{
				Cloudcore_Campaign previousValue = this._Cloudcore_Campaign.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Campaign.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Campaign.Entity = null;
						previousValue.Cloudcore_CampaignItem.Remove(this);
					}
					this._Cloudcore_Campaign.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignItem.Add(this);
						this._CampaignID = value.CampaignID;
					}
					else
					{
						this._CampaignID = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Campaign");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Worklist", Storage="_Cloudcore_Worklist", ThisKey="InstanceId", OtherKey="InstanceId", IsForeignKey=true)]
		public Cloudcore_Worklist Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist.Entity;
			}
			set
			{
				Cloudcore_Worklist previousValue = this._Cloudcore_Worklist.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Worklist.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Worklist.Entity = null;
						previousValue.Cloudcore_CampaignItem.Remove(this);
					}
					this._Cloudcore_Worklist.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignItem.Add(this);
						this._InstanceId = value.InstanceId;
					}
					else
					{
						this._InstanceId = default(long);
					}
					this.SendPropertyChanged("Cloudcore_Worklist");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.CampaignUser")]
	public partial class Cloudcore_CampaignUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CampaignID;
		
		private int _UserId;
		
		private bool _Active;
		
		private EntityRef<Cloudcore_Campaign> _Cloudcore_Campaign;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCampaignIDChanging(int value);
    partial void OnCampaignIDChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    #endregion
		
		public Cloudcore_CampaignUser()
		{
			this._Cloudcore_Campaign = default(EntityRef<Cloudcore_Campaign>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					if (this._Cloudcore_Campaign.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCampaignIDChanging(value);
					this.SendPropertyChanging();
					this._CampaignID = value;
					this.SendPropertyChanged("CampaignID");
					this.OnCampaignIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignUser_Campaign", Storage="_Cloudcore_Campaign", ThisKey="CampaignID", OtherKey="CampaignID", IsForeignKey=true)]
		public Cloudcore_Campaign Cloudcore_Campaign
		{
			get
			{
				return this._Cloudcore_Campaign.Entity;
			}
			set
			{
				Cloudcore_Campaign previousValue = this._Cloudcore_Campaign.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Campaign.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Campaign.Entity = null;
						previousValue.Cloudcore_CampaignUser.Remove(this);
					}
					this._Cloudcore_Campaign.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignUser.Add(this);
						this._CampaignID = value.CampaignID;
					}
					else
					{
						this._CampaignID = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Campaign");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignUser_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_CampaignUser.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CampaignUser.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.CostLedger")]
	public partial class Cloudcore_CostLedger : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _LedgerID;
		
		private long _InstanceId;
		
		private int _ActivityModelId;
		
		private decimal _Cost;
		
		private System.DateTime _TransDate;
		
		private int _PeriodSeq;
		
		private bool _Exported;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcore_Period> _Cloudcore_Period;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLedgerIDChanging(long value);
    partial void OnLedgerIDChanged();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnActivityModelIdChanging(int value);
    partial void OnActivityModelIdChanged();
    partial void OnCostChanging(decimal value);
    partial void OnCostChanged();
    partial void OnTransDateChanging(System.DateTime value);
    partial void OnTransDateChanged();
    partial void OnPeriodSeqChanging(int value);
    partial void OnPeriodSeqChanged();
    partial void OnExportedChanging(bool value);
    partial void OnExportedChanged();
    #endregion
		
		public Cloudcore_CostLedger()
		{
			this._Cloudcoremodel_ActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._Cloudcore_Period = default(EntityRef<Cloudcore_Period>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LedgerID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long LedgerID
		{
			get
			{
				return this._LedgerID;
			}
			set
			{
				if ((this._LedgerID != value))
				{
					this.OnLedgerIDChanging(value);
					this.SendPropertyChanging();
					this._LedgerID = value;
					this.SendPropertyChanged("LedgerID");
					this.OnLedgerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					if (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityModelId = value;
					this.SendPropertyChanged("ActivityModelId");
					this.OnActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost", DbType="Money NOT NULL")]
		public decimal Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				if ((this._Cost != value))
				{
					this.OnCostChanging(value);
					this.SendPropertyChanging();
					this._Cost = value;
					this.SendPropertyChanged("Cost");
					this.OnCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransDate
		{
			get
			{
				return this._TransDate;
			}
			set
			{
				if ((this._TransDate != value))
				{
					this.OnTransDateChanging(value);
					this.SendPropertyChanging();
					this._TransDate = value;
					this.SendPropertyChanged("TransDate");
					this.OnTransDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodSeq", DbType="Int NOT NULL")]
		public int PeriodSeq
		{
			get
			{
				return this._PeriodSeq;
			}
			set
			{
				if ((this._PeriodSeq != value))
				{
					if (this._Cloudcore_Period.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPeriodSeqChanging(value);
					this.SendPropertyChanging();
					this._PeriodSeq = value;
					this.SendPropertyChanged("PeriodSeq");
					this.OnPeriodSeqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Exported", DbType="Bit NOT NULL")]
		public bool Exported
		{
			get
			{
				return this._Exported;
			}
			set
			{
				if ((this._Exported != value))
				{
					this.OnExportedChanging(value);
					this.SendPropertyChanging();
					this._Exported = value;
					this.SendPropertyChanged("Exported");
					this.OnExportedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CostLedger_ActivityModel", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Cloudcoremodel_ActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityModel.Entity = null;
						previousValue.Cloudcore_CostLedger.Remove(this);
					}
					this._Cloudcoremodel_ActivityModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CostLedger.Add(this);
						this._ActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._ActivityModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CostLedger_Period", Storage="_Cloudcore_Period", ThisKey="PeriodSeq", OtherKey="PeriodSeq", IsForeignKey=true)]
		public Cloudcore_Period Cloudcore_Period
		{
			get
			{
				return this._Cloudcore_Period.Entity;
			}
			set
			{
				Cloudcore_Period previousValue = this._Cloudcore_Period.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Period.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Period.Entity = null;
						previousValue.Cloudcore_CostLedger.Remove(this);
					}
					this._Cloudcore_Period.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_CostLedger.Add(this);
						this._PeriodSeq = value.PeriodSeq;
					}
					else
					{
						this._PeriodSeq = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Period");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.CostType")]
	public partial class Cloudcoremodel_CostType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CostTypeId;
		
		private string _CostType;
		
		private EntitySet<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCostTypeIdChanging(int value);
    partial void OnCostTypeIdChanged();
    partial void OnCostTypeChanging(string value);
    partial void OnCostTypeChanged();
    #endregion
		
		public Cloudcoremodel_CostType()
		{
			this._Cloudcoremodel_ActivityModel = new EntitySet<Cloudcoremodel_ActivityModel>(new Action<Cloudcoremodel_ActivityModel>(this.attach_Cloudcoremodel_ActivityModel), new Action<Cloudcoremodel_ActivityModel>(this.detach_Cloudcoremodel_ActivityModel));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CostTypeId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CostTypeId
		{
			get
			{
				return this._CostTypeId;
			}
			set
			{
				if ((this._CostTypeId != value))
				{
					this.OnCostTypeIdChanging(value);
					this.SendPropertyChanging();
					this._CostTypeId = value;
					this.SendPropertyChanged("CostTypeId");
					this.OnCostTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CostType", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string CostType
		{
			get
			{
				return this._CostType;
			}
			set
			{
				if ((this._CostType != value))
				{
					this.OnCostTypeChanging(value);
					this.SendPropertyChanging();
					this._CostType = value;
					this.SendPropertyChanged("CostType");
					this.OnCostTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_CostType", Storage="_Cloudcoremodel_ActivityModel", ThisKey="CostTypeId", OtherKey="CostTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ActivityModel> Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel;
			}
			set
			{
				this._Cloudcoremodel_ActivityModel.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_CostType = this;
		}
		
		private void detach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_CostType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Dashboard")]
	public partial class Cloudcore_Dashboard : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DashboardId;
		
		private int _SystemModuleId;
		
		private string _ClassName;
		
		private string _Title;
		
		private string _Description;
		
		private EntityRef<Cloudcore_SystemModule> _Cloudcore_SystemModule;
		
		private EntitySet<Cloudcore_DashboardRight> _Cloudcore_DashboardRight;
		
		private EntitySet<Cloudcore_DashboardUserAllocation> _Cloudcore_DashboardUserAllocation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDashboardIdChanging(int value);
    partial void OnDashboardIdChanged();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    partial void OnClassNameChanging(string value);
    partial void OnClassNameChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Cloudcore_Dashboard()
		{
			this._Cloudcore_SystemModule = default(EntityRef<Cloudcore_SystemModule>);
			this._Cloudcore_DashboardRight = new EntitySet<Cloudcore_DashboardRight>(new Action<Cloudcore_DashboardRight>(this.attach_Cloudcore_DashboardRight), new Action<Cloudcore_DashboardRight>(this.detach_Cloudcore_DashboardRight));
			this._Cloudcore_DashboardUserAllocation = new EntitySet<Cloudcore_DashboardUserAllocation>(new Action<Cloudcore_DashboardUserAllocation>(this.attach_Cloudcore_DashboardUserAllocation), new Action<Cloudcore_DashboardUserAllocation>(this.detach_Cloudcore_DashboardUserAllocation));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DashboardId
		{
			get
			{
				return this._DashboardId;
			}
			set
			{
				if ((this._DashboardId != value))
				{
					this.OnDashboardIdChanging(value);
					this.SendPropertyChanging();
					this._DashboardId = value;
					this.SendPropertyChanged("DashboardId");
					this.OnDashboardIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					if (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string ClassName
		{
			get
			{
				return this._ClassName;
			}
			set
			{
				if ((this._ClassName != value))
				{
					this.OnClassNameChanging(value);
					this.SendPropertyChanging();
					this._ClassName = value;
					this.SendPropertyChanged("ClassName");
					this.OnClassNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Dashboard_SystemModule", Storage="_Cloudcore_SystemModule", ThisKey="SystemModuleId", OtherKey="SystemModuleId", IsForeignKey=true)]
		public Cloudcore_SystemModule Cloudcore_SystemModule
		{
			get
			{
				return this._Cloudcore_SystemModule.Entity;
			}
			set
			{
				Cloudcore_SystemModule previousValue = this._Cloudcore_SystemModule.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemModule.Entity = null;
						previousValue.Cloudcore_Dashboard.Remove(this);
					}
					this._Cloudcore_SystemModule.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Dashboard.Add(this);
						this._SystemModuleId = value.SystemModuleId;
					}
					else
					{
						this._SystemModuleId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemModule");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardRight_Dashboard", Storage="_Cloudcore_DashboardRight", ThisKey="DashboardId", OtherKey="DashboardId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_DashboardRight> Cloudcore_DashboardRight
		{
			get
			{
				return this._Cloudcore_DashboardRight;
			}
			set
			{
				this._Cloudcore_DashboardRight.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardUserAllocation_Dashboard", Storage="_Cloudcore_DashboardUserAllocation", ThisKey="DashboardId", OtherKey="DashboardId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_DashboardUserAllocation> Cloudcore_DashboardUserAllocation
		{
			get
			{
				return this._Cloudcore_DashboardUserAllocation;
			}
			set
			{
				this._Cloudcore_DashboardUserAllocation.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_DashboardRight(Cloudcore_DashboardRight entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Dashboard = this;
		}
		
		private void detach_Cloudcore_DashboardRight(Cloudcore_DashboardRight entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Dashboard = null;
		}
		
		private void attach_Cloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Dashboard = this;
		}
		
		private void detach_Cloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Dashboard = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.DashboardRight")]
	public partial class Cloudcore_DashboardRight : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DashboardId;
		
		private int _AccessPoolId;
		
		private EntityRef<Cloudcore_AccessPool> _Cloudcore_AccessPool;
		
		private EntityRef<Cloudcore_Dashboard> _Cloudcore_Dashboard;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDashboardIdChanging(int value);
    partial void OnDashboardIdChanged();
    partial void OnAccessPoolIdChanging(int value);
    partial void OnAccessPoolIdChanged();
    #endregion
		
		public Cloudcore_DashboardRight()
		{
			this._Cloudcore_AccessPool = default(EntityRef<Cloudcore_AccessPool>);
			this._Cloudcore_Dashboard = default(EntityRef<Cloudcore_Dashboard>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int DashboardId
		{
			get
			{
				return this._DashboardId;
			}
			set
			{
				if ((this._DashboardId != value))
				{
					if (this._Cloudcore_Dashboard.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDashboardIdChanging(value);
					this.SendPropertyChanging();
					this._DashboardId = value;
					this.SendPropertyChanged("DashboardId");
					this.OnDashboardIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					if (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAccessPoolIdChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolId = value;
					this.SendPropertyChanged("AccessPoolId");
					this.OnAccessPoolIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardRight_AccessRight", Storage="_Cloudcore_AccessPool", ThisKey="AccessPoolId", OtherKey="AccessPoolId", IsForeignKey=true)]
		public Cloudcore_AccessPool Cloudcore_AccessPool
		{
			get
			{
				return this._Cloudcore_AccessPool.Entity;
			}
			set
			{
				Cloudcore_AccessPool previousValue = this._Cloudcore_AccessPool.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_AccessPool.Entity = null;
						previousValue.Cloudcore_DashboardRight.Remove(this);
					}
					this._Cloudcore_AccessPool.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_DashboardRight.Add(this);
						this._AccessPoolId = value.AccessPoolId;
					}
					else
					{
						this._AccessPoolId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_AccessPool");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardRight_Dashboard", Storage="_Cloudcore_Dashboard", ThisKey="DashboardId", OtherKey="DashboardId", IsForeignKey=true)]
		public Cloudcore_Dashboard Cloudcore_Dashboard
		{
			get
			{
				return this._Cloudcore_Dashboard.Entity;
			}
			set
			{
				Cloudcore_Dashboard previousValue = this._Cloudcore_Dashboard.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Dashboard.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Dashboard.Entity = null;
						previousValue.Cloudcore_DashboardRight.Remove(this);
					}
					this._Cloudcore_Dashboard.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_DashboardRight.Add(this);
						this._DashboardId = value.DashboardId;
					}
					else
					{
						this._DashboardId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Dashboard");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.DashboardUserAllocation")]
	public partial class Cloudcore_DashboardUserAllocation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DashboardUserAllocationId;
		
		private int _UserId;
		
		private int _DashboardId;
		
		private int _TilePosition;
		
		private EntityRef<Cloudcore_Dashboard> _Cloudcore_Dashboard;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDashboardUserAllocationIdChanging(int value);
    partial void OnDashboardUserAllocationIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnDashboardIdChanging(int value);
    partial void OnDashboardIdChanged();
    partial void OnTilePositionChanging(int value);
    partial void OnTilePositionChanged();
    #endregion
		
		public Cloudcore_DashboardUserAllocation()
		{
			this._Cloudcore_Dashboard = default(EntityRef<Cloudcore_Dashboard>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardUserAllocationId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DashboardUserAllocationId
		{
			get
			{
				return this._DashboardUserAllocationId;
			}
			set
			{
				if ((this._DashboardUserAllocationId != value))
				{
					this.OnDashboardUserAllocationIdChanging(value);
					this.SendPropertyChanging();
					this._DashboardUserAllocationId = value;
					this.SendPropertyChanged("DashboardUserAllocationId");
					this.OnDashboardUserAllocationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardId", DbType="Int NOT NULL")]
		public int DashboardId
		{
			get
			{
				return this._DashboardId;
			}
			set
			{
				if ((this._DashboardId != value))
				{
					if (this._Cloudcore_Dashboard.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDashboardIdChanging(value);
					this.SendPropertyChanging();
					this._DashboardId = value;
					this.SendPropertyChanged("DashboardId");
					this.OnDashboardIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TilePosition", DbType="Int NOT NULL")]
		public int TilePosition
		{
			get
			{
				return this._TilePosition;
			}
			set
			{
				if ((this._TilePosition != value))
				{
					this.OnTilePositionChanging(value);
					this.SendPropertyChanging();
					this._TilePosition = value;
					this.SendPropertyChanged("TilePosition");
					this.OnTilePositionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardUserAllocation_Dashboard", Storage="_Cloudcore_Dashboard", ThisKey="DashboardId", OtherKey="DashboardId", IsForeignKey=true)]
		public Cloudcore_Dashboard Cloudcore_Dashboard
		{
			get
			{
				return this._Cloudcore_Dashboard.Entity;
			}
			set
			{
				Cloudcore_Dashboard previousValue = this._Cloudcore_Dashboard.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Dashboard.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Dashboard.Entity = null;
						previousValue.Cloudcore_DashboardUserAllocation.Remove(this);
					}
					this._Cloudcore_Dashboard.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_DashboardUserAllocation.Add(this);
						this._DashboardId = value.DashboardId;
					}
					else
					{
						this._DashboardId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Dashboard");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardUserAllocation_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_DashboardUserAllocation.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_DashboardUserAllocation.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Favourite")]
	public partial class Cloudcore_Favourite : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _FavouriteReference;
		
		private short _FavouriteTypeId;
		
		private string _FavouriteType;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnFavouriteReferenceChanging(string value);
    partial void OnFavouriteReferenceChanged();
    partial void OnFavouriteTypeIdChanging(short value);
    partial void OnFavouriteTypeIdChanged();
    partial void OnFavouriteTypeChanging(string value);
    partial void OnFavouriteTypeChanged();
    #endregion
		
		public Cloudcore_Favourite()
		{
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FavouriteReference", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string FavouriteReference
		{
			get
			{
				return this._FavouriteReference;
			}
			set
			{
				if ((this._FavouriteReference != value))
				{
					this.OnFavouriteReferenceChanging(value);
					this.SendPropertyChanging();
					this._FavouriteReference = value;
					this.SendPropertyChanged("FavouriteReference");
					this.OnFavouriteReferenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FavouriteTypeId", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short FavouriteTypeId
		{
			get
			{
				return this._FavouriteTypeId;
			}
			set
			{
				if ((this._FavouriteTypeId != value))
				{
					this.OnFavouriteTypeIdChanging(value);
					this.SendPropertyChanging();
					this._FavouriteTypeId = value;
					this.SendPropertyChanged("FavouriteTypeId");
					this.OnFavouriteTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FavouriteType", AutoSync=AutoSync.Always, DbType="VarChar(9) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [FavouriteTypeId] when (0) then \'Menu\' when (1) then \'Dashboard\' else \'Unkn" +
			"own\' end)")]
		public string FavouriteType
		{
			get
			{
				return this._FavouriteType;
			}
			set
			{
				if ((this._FavouriteType != value))
				{
					this.OnFavouriteTypeChanging(value);
					this.SendPropertyChanging();
					this._FavouriteType = value;
					this.SendPropertyChanged("FavouriteType");
					this.OnFavouriteTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Favourite_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_Favourite.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Favourite.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.FlowModel")]
	public partial class Cloudcoremodel_FlowModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _FlowModelId;
		
		private System.Guid _FlowGuid;
		
		private int _ProcessRevisionId;
		
		private int _FromActivityModelId;
		
		private string _Outcome;
		
		private int _ToActivityModelId;
		
		private bool _OptimalFlow;
		
		private bool _NegativeFlow;
		
		private string _Storyline;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcoremodel_ActivityModel> _ToActivityModel;
		
		private EntityRef<Cloudcoremodel_ProcessRevision> _Cloudcoremodel_ProcessRevision;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFlowModelIdChanging(int value);
    partial void OnFlowModelIdChanged();
    partial void OnFlowGuidChanging(System.Guid value);
    partial void OnFlowGuidChanged();
    partial void OnProcessRevisionIdChanging(int value);
    partial void OnProcessRevisionIdChanged();
    partial void OnFromActivityModelIdChanging(int value);
    partial void OnFromActivityModelIdChanged();
    partial void OnOutcomeChanging(string value);
    partial void OnOutcomeChanged();
    partial void OnToActivityModelIdChanging(int value);
    partial void OnToActivityModelIdChanged();
    partial void OnOptimalFlowChanging(bool value);
    partial void OnOptimalFlowChanged();
    partial void OnNegativeFlowChanging(bool value);
    partial void OnNegativeFlowChanged();
    partial void OnStorylineChanging(string value);
    partial void OnStorylineChanged();
    #endregion
		
		public Cloudcoremodel_FlowModel()
		{
			this._Cloudcoremodel_ActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._ToActivityModel = default(EntityRef<Cloudcoremodel_ActivityModel>);
			this._Cloudcoremodel_ProcessRevision = default(EntityRef<Cloudcoremodel_ProcessRevision>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowModelId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int FlowModelId
		{
			get
			{
				return this._FlowModelId;
			}
			set
			{
				if ((this._FlowModelId != value))
				{
					this.OnFlowModelIdChanging(value);
					this.SendPropertyChanging();
					this._FlowModelId = value;
					this.SendPropertyChanged("FlowModelId");
					this.OnFlowModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid FlowGuid
		{
			get
			{
				return this._FlowGuid;
			}
			set
			{
				if ((this._FlowGuid != value))
				{
					this.OnFlowGuidChanging(value);
					this.SendPropertyChanging();
					this._FlowGuid = value;
					this.SendPropertyChanged("FlowGuid");
					this.OnFlowGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					if (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessRevisionIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevisionId = value;
					this.SendPropertyChanged("ProcessRevisionId");
					this.OnProcessRevisionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityModelId", DbType="Int NOT NULL")]
		public int FromActivityModelId
		{
			get
			{
				return this._FromActivityModelId;
			}
			set
			{
				if ((this._FromActivityModelId != value))
				{
					if (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFromActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._FromActivityModelId = value;
					this.SendPropertyChanged("FromActivityModelId");
					this.OnFromActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Outcome", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Outcome
		{
			get
			{
				return this._Outcome;
			}
			set
			{
				if ((this._Outcome != value))
				{
					this.OnOutcomeChanging(value);
					this.SendPropertyChanging();
					this._Outcome = value;
					this.SendPropertyChanged("Outcome");
					this.OnOutcomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityModelId", DbType="Int NOT NULL")]
		public int ToActivityModelId
		{
			get
			{
				return this._ToActivityModelId;
			}
			set
			{
				if ((this._ToActivityModelId != value))
				{
					if (this._ToActivityModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnToActivityModelIdChanging(value);
					this.SendPropertyChanging();
					this._ToActivityModelId = value;
					this.SendPropertyChanged("ToActivityModelId");
					this.OnToActivityModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OptimalFlow", DbType="Bit NOT NULL")]
		public bool OptimalFlow
		{
			get
			{
				return this._OptimalFlow;
			}
			set
			{
				if ((this._OptimalFlow != value))
				{
					this.OnOptimalFlowChanging(value);
					this.SendPropertyChanging();
					this._OptimalFlow = value;
					this.SendPropertyChanged("OptimalFlow");
					this.OnOptimalFlowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NegativeFlow", DbType="Bit NOT NULL")]
		public bool NegativeFlow
		{
			get
			{
				return this._NegativeFlow;
			}
			set
			{
				if ((this._NegativeFlow != value))
				{
					this.OnNegativeFlowChanging(value);
					this.SendPropertyChanging();
					this._NegativeFlow = value;
					this.SendPropertyChanged("NegativeFlow");
					this.OnNegativeFlowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Storyline", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Storyline
		{
			get
			{
				return this._Storyline;
			}
			set
			{
				if ((this._Storyline != value))
				{
					this.OnStorylineChanging(value);
					this.SendPropertyChanging();
					this._Storyline = value;
					this.SendPropertyChanged("Storyline");
					this.OnStorylineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ActivityModel_From", Storage="_Cloudcoremodel_ActivityModel", ThisKey="FromActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._Cloudcoremodel_ActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ActivityModel.Entity = null;
						previousValue.Cloudcoremodel_FlowModel.Remove(this);
					}
					this._Cloudcoremodel_ActivityModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_FlowModel.Add(this);
						this._FromActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._FromActivityModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ActivityModel_To", Storage="_ToActivityModel", ThisKey="ToActivityModelId", OtherKey="ActivityModelId", IsForeignKey=true)]
		public Cloudcoremodel_ActivityModel ToActivityModel
		{
			get
			{
				return this._ToActivityModel.Entity;
			}
			set
			{
				Cloudcoremodel_ActivityModel previousValue = this._ToActivityModel.Entity;
				if (((previousValue != value) 
							|| (this._ToActivityModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ToActivityModel.Entity = null;
						previousValue.FlowModel_ActivityModel_To.Remove(this);
					}
					this._ToActivityModel.Entity = value;
					if ((value != null))
					{
						value.FlowModel_ActivityModel_To.Add(this);
						this._ToActivityModelId = value.ActivityModelId;
					}
					else
					{
						this._ToActivityModelId = default(int);
					}
					this.SendPropertyChanged("ToActivityModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ProcessModel", Storage="_Cloudcoremodel_ProcessRevision", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", IsForeignKey=true)]
		public Cloudcoremodel_ProcessRevision Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this._Cloudcoremodel_ProcessRevision.Entity;
			}
			set
			{
				Cloudcoremodel_ProcessRevision previousValue = this._Cloudcoremodel_ProcessRevision.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ProcessRevision.Entity = null;
						previousValue.Cloudcoremodel_FlowModel.Remove(this);
					}
					this._Cloudcoremodel_ProcessRevision.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_FlowModel.Add(this);
						this._ProcessRevisionId = value.ProcessRevisionId;
					}
					else
					{
						this._ProcessRevisionId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ProcessRevision");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.LoginHistory")]
	public partial class Cloudcore_LoginHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private System.DateTime _Connected;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnConnectedChanging(System.DateTime value);
    partial void OnConnectedChanged();
    #endregion
		
		public Cloudcore_LoginHistory()
		{
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Connected", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime Connected
		{
			get
			{
				return this._Connected;
			}
			set
			{
				if ((this._Connected != value))
				{
					this.OnConnectedChanging(value);
					this.SendPropertyChanging();
					this._Connected = value;
					this.SendPropertyChanged("Connected");
					this.OnConnectedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_LoginHistory_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_LoginHistory.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_LoginHistory.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Notification")]
	public partial class Cloudcore_Notification : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _NotificationId;
		
		private string _Subject;
		
		private string _Message;
		
		private System.DateTime _Created;
		
		private int _Creator;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNotificationIdChanging(int value);
    partial void OnNotificationIdChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnCreatedChanging(System.DateTime value);
    partial void OnCreatedChanged();
    partial void OnCreatorChanging(int value);
    partial void OnCreatorChanged();
    #endregion
		
		public Cloudcore_Notification()
		{
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificationId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int NotificationId
		{
			get
			{
				return this._NotificationId;
			}
			set
			{
				if ((this._NotificationId != value))
				{
					this.OnNotificationIdChanging(value);
					this.SendPropertyChanging();
					this._NotificationId = value;
					this.SendPropertyChanged("NotificationId");
					this.OnNotificationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged("Subject");
					this.OnSubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Creator", DbType="Int NOT NULL")]
		public int Creator
		{
			get
			{
				return this._Creator;
			}
			set
			{
				if ((this._Creator != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCreatorChanging(value);
					this.SendPropertyChanging();
					this._Creator = value;
					this.SendPropertyChanged("Creator");
					this.OnCreatorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Notification_Creator", Storage="_Cloudcore_User", ThisKey="Creator", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_Notification.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Notification.Add(this);
						this._Creator = value.UserId;
					}
					else
					{
						this._Creator = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Period")]
	public partial class Cloudcore_Period : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PeriodSeq;
		
		private System.DateTime _StartDate;
		
		private System.DateTime _EndDate;
		
		private int _PeriodMonth;
		
		private int _PeriodYear;
		
		private string _PeriodTitle;
		
		private EntitySet<Cloudcore_CostLedger> _Cloudcore_CostLedger;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPeriodSeqChanging(int value);
    partial void OnPeriodSeqChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnEndDateChanging(System.DateTime value);
    partial void OnEndDateChanged();
    partial void OnPeriodMonthChanging(int value);
    partial void OnPeriodMonthChanged();
    partial void OnPeriodYearChanging(int value);
    partial void OnPeriodYearChanged();
    partial void OnPeriodTitleChanging(string value);
    partial void OnPeriodTitleChanged();
    #endregion
		
		public Cloudcore_Period()
		{
			this._Cloudcore_CostLedger = new EntitySet<Cloudcore_CostLedger>(new Action<Cloudcore_CostLedger>(this.attach_Cloudcore_CostLedger), new Action<Cloudcore_CostLedger>(this.detach_Cloudcore_CostLedger));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodSeq", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PeriodSeq
		{
			get
			{
				return this._PeriodSeq;
			}
			set
			{
				if ((this._PeriodSeq != value))
				{
					this.OnPeriodSeqChanging(value);
					this.SendPropertyChanging();
					this._PeriodSeq = value;
					this.SendPropertyChanged("PeriodSeq");
					this.OnPeriodSeqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL")]
		public System.DateTime StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				if ((this._StartDate != value))
				{
					this.OnStartDateChanging(value);
					this.SendPropertyChanging();
					this._StartDate = value;
					this.SendPropertyChanged("StartDate");
					this.OnStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="DateTime NOT NULL")]
		public System.DateTime EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				if ((this._EndDate != value))
				{
					this.OnEndDateChanging(value);
					this.SendPropertyChanging();
					this._EndDate = value;
					this.SendPropertyChanged("EndDate");
					this.OnEndDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodMonth", DbType="Int NOT NULL")]
		public int PeriodMonth
		{
			get
			{
				return this._PeriodMonth;
			}
			set
			{
				if ((this._PeriodMonth != value))
				{
					this.OnPeriodMonthChanging(value);
					this.SendPropertyChanging();
					this._PeriodMonth = value;
					this.SendPropertyChanged("PeriodMonth");
					this.OnPeriodMonthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodYear", DbType="Int NOT NULL")]
		public int PeriodYear
		{
			get
			{
				return this._PeriodYear;
			}
			set
			{
				if ((this._PeriodYear != value))
				{
					this.OnPeriodYearChanging(value);
					this.SendPropertyChanging();
					this._PeriodYear = value;
					this.SendPropertyChanged("PeriodYear");
					this.OnPeriodYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodTitle", AutoSync=AutoSync.Always, DbType="NVarChar(63)", IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="((CONVERT([nvarchar](30),[StartDate],(106))+\' - \')+CONVERT([nvarchar](30),[EndDat" +
			"e],(106)))")]
		public string PeriodTitle
		{
			get
			{
				return this._PeriodTitle;
			}
			set
			{
				if ((this._PeriodTitle != value))
				{
					this.OnPeriodTitleChanging(value);
					this.SendPropertyChanging();
					this._PeriodTitle = value;
					this.SendPropertyChanged("PeriodTitle");
					this.OnPeriodTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CostLedger_Period", Storage="_Cloudcore_CostLedger", ThisKey="PeriodSeq", OtherKey="PeriodSeq", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CostLedger> Cloudcore_CostLedger
		{
			get
			{
				return this._Cloudcore_CostLedger;
			}
			set
			{
				this._Cloudcore_CostLedger.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_CostLedger(Cloudcore_CostLedger entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Period = this;
		}
		
		private void detach_Cloudcore_CostLedger(Cloudcore_CostLedger entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Period = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ProcessHistory")]
	public partial class Cloudcore_ProcessHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ProcessArchiveId;
		
		private long _InstanceId;
		
		private long _PInstanceId;
		
		private int _ProcessModelId;
		
		private long _KeyValue;
		
		private System.DateTime _Started;
		
		private System.Nullable<System.DateTime> _Ended;
		
		private int _StatusId;
		
		private EntityRef<Cloudcoremodel_ProcessModel> _Cloudcoremodel_ProcessModel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProcessArchiveIdChanging(long value);
    partial void OnProcessArchiveIdChanged();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnPInstanceIdChanging(long value);
    partial void OnPInstanceIdChanged();
    partial void OnProcessModelIdChanging(int value);
    partial void OnProcessModelIdChanged();
    partial void OnKeyValueChanging(long value);
    partial void OnKeyValueChanged();
    partial void OnStartedChanging(System.DateTime value);
    partial void OnStartedChanged();
    partial void OnEndedChanging(System.Nullable<System.DateTime> value);
    partial void OnEndedChanged();
    partial void OnStatusIdChanging(int value);
    partial void OnStatusIdChanged();
    #endregion
		
		public Cloudcore_ProcessHistory()
		{
			this._Cloudcoremodel_ProcessModel = default(EntityRef<Cloudcoremodel_ProcessModel>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessArchiveId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ProcessArchiveId
		{
			get
			{
				return this._ProcessArchiveId;
			}
			set
			{
				if ((this._ProcessArchiveId != value))
				{
					this.OnProcessArchiveIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessArchiveId = value;
					this.SendPropertyChanged("ProcessArchiveId");
					this.OnProcessArchiveIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PInstanceId", DbType="BigInt NOT NULL")]
		public long PInstanceId
		{
			get
			{
				return this._PInstanceId;
			}
			set
			{
				if ((this._PInstanceId != value))
				{
					this.OnPInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._PInstanceId = value;
					this.SendPropertyChanged("PInstanceId");
					this.OnPInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					if (this._Cloudcoremodel_ProcessModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessModelIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessModelId = value;
					this.SendPropertyChanged("ProcessModelId");
					this.OnProcessModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this.OnKeyValueChanging(value);
					this.SendPropertyChanging();
					this._KeyValue = value;
					this.SendPropertyChanged("KeyValue");
					this.OnKeyValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Started", DbType="DateTime NOT NULL")]
		public System.DateTime Started
		{
			get
			{
				return this._Started;
			}
			set
			{
				if ((this._Started != value))
				{
					this.OnStartedChanging(value);
					this.SendPropertyChanging();
					this._Started = value;
					this.SendPropertyChanged("Started");
					this.OnStartedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ended", DbType="DateTime")]
		public System.Nullable<System.DateTime> Ended
		{
			get
			{
				return this._Ended;
			}
			set
			{
				if ((this._Ended != value))
				{
					this.OnEndedChanging(value);
					this.SendPropertyChanging();
					this._Ended = value;
					this.SendPropertyChanged("Ended");
					this.OnEndedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusId", DbType="Int NOT NULL")]
		public int StatusId
		{
			get
			{
				return this._StatusId;
			}
			set
			{
				if ((this._StatusId != value))
				{
					this.OnStatusIdChanging(value);
					this.SendPropertyChanging();
					this._StatusId = value;
					this.SendPropertyChanged("StatusId");
					this.OnStatusIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessHistory_ProcessModel", Storage="_Cloudcoremodel_ProcessModel", ThisKey="ProcessModelId", OtherKey="ProcessModelId", IsForeignKey=true)]
		public Cloudcoremodel_ProcessModel Cloudcoremodel_ProcessModel
		{
			get
			{
				return this._Cloudcoremodel_ProcessModel.Entity;
			}
			set
			{
				Cloudcoremodel_ProcessModel previousValue = this._Cloudcoremodel_ProcessModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ProcessModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ProcessModel.Entity = null;
						previousValue.Cloudcore_ProcessHistory.Remove(this);
					}
					this._Cloudcoremodel_ProcessModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ProcessHistory.Add(this);
						this._ProcessModelId = value.ProcessModelId;
					}
					else
					{
						this._ProcessModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ProcessModel");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.ProcessModel")]
	public partial class Cloudcoremodel_ProcessModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProcessModelId;
		
		private System.Guid _ProcessGuid;
		
		private string _ProcessName;
		
		private EntitySet<Cloudcore_ProcessHistory> _Cloudcore_ProcessHistory;
		
		private EntitySet<Cloudcoremodel_ProcessRevision> _Cloudcoremodel_ProcessRevision;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProcessModelIdChanging(int value);
    partial void OnProcessModelIdChanged();
    partial void OnProcessGuidChanging(System.Guid value);
    partial void OnProcessGuidChanged();
    partial void OnProcessNameChanging(string value);
    partial void OnProcessNameChanged();
    #endregion
		
		public Cloudcoremodel_ProcessModel()
		{
			this._Cloudcore_ProcessHistory = new EntitySet<Cloudcore_ProcessHistory>(new Action<Cloudcore_ProcessHistory>(this.attach_Cloudcore_ProcessHistory), new Action<Cloudcore_ProcessHistory>(this.detach_Cloudcore_ProcessHistory));
			this._Cloudcoremodel_ProcessRevision = new EntitySet<Cloudcoremodel_ProcessRevision>(new Action<Cloudcoremodel_ProcessRevision>(this.attach_Cloudcoremodel_ProcessRevision), new Action<Cloudcoremodel_ProcessRevision>(this.detach_Cloudcoremodel_ProcessRevision));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this.OnProcessModelIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessModelId = value;
					this.SendPropertyChanged("ProcessModelId");
					this.OnProcessModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this.OnProcessGuidChanging(value);
					this.SendPropertyChanging();
					this._ProcessGuid = value;
					this.SendPropertyChanged("ProcessGuid");
					this.OnProcessGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this.OnProcessNameChanging(value);
					this.SendPropertyChanging();
					this._ProcessName = value;
					this.SendPropertyChanged("ProcessName");
					this.OnProcessNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessHistory_ProcessModel", Storage="_Cloudcore_ProcessHistory", ThisKey="ProcessModelId", OtherKey="ProcessModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ProcessHistory> Cloudcore_ProcessHistory
		{
			get
			{
				return this._Cloudcore_ProcessHistory;
			}
			set
			{
				this._Cloudcore_ProcessHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_ProcessModel", Storage="_Cloudcoremodel_ProcessRevision", ThisKey="ProcessModelId", OtherKey="ProcessModelId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ProcessRevision> Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this._Cloudcoremodel_ProcessRevision;
			}
			set
			{
				this._Cloudcoremodel_ProcessRevision.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ProcessHistory(Cloudcore_ProcessHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessModel = this;
		}
		
		private void detach_Cloudcore_ProcessHistory(Cloudcore_ProcessHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessModel = null;
		}
		
		private void attach_Cloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessModel = this;
		}
		
		private void detach_Cloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessModel = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.ProcessRevision")]
	public partial class Cloudcoremodel_ProcessRevision : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProcessRevisionId;
		
		private int _ProcessModelId;
		
		private int _ProcessRevision;
		
		private string _CheckSum;
		
		private int _UserId;
		
		private int _ManagerId;
		
		private System.DateTime _Changed;
		
		private EntitySet<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntitySet<Cloudcoremodel_FlowModel> _Cloudcoremodel_FlowModel;
		
		private EntityRef<Cloudcoremodel_ProcessModel> _Cloudcoremodel_ProcessModel;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
		private EntityRef<Cloudcore_User> _Manager;
		
		private EntitySet<Cloudcoremodel_SubProcess> _Cloudcoremodel_SubProcess;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProcessRevisionIdChanging(int value);
    partial void OnProcessRevisionIdChanged();
    partial void OnProcessModelIdChanging(int value);
    partial void OnProcessModelIdChanged();
    partial void OnProcessRevisionChanging(int value);
    partial void OnProcessRevisionChanged();
    partial void OnCheckSumChanging(string value);
    partial void OnCheckSumChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnManagerIdChanging(int value);
    partial void OnManagerIdChanged();
    partial void OnChangedChanging(System.DateTime value);
    partial void OnChangedChanged();
    #endregion
		
		public Cloudcoremodel_ProcessRevision()
		{
			this._Cloudcoremodel_ActivityModel = new EntitySet<Cloudcoremodel_ActivityModel>(new Action<Cloudcoremodel_ActivityModel>(this.attach_Cloudcoremodel_ActivityModel), new Action<Cloudcoremodel_ActivityModel>(this.detach_Cloudcoremodel_ActivityModel));
			this._Cloudcoremodel_FlowModel = new EntitySet<Cloudcoremodel_FlowModel>(new Action<Cloudcoremodel_FlowModel>(this.attach_Cloudcoremodel_FlowModel), new Action<Cloudcoremodel_FlowModel>(this.detach_Cloudcoremodel_FlowModel));
			this._Cloudcoremodel_ProcessModel = default(EntityRef<Cloudcoremodel_ProcessModel>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			this._Manager = default(EntityRef<Cloudcore_User>);
			this._Cloudcoremodel_SubProcess = new EntitySet<Cloudcoremodel_SubProcess>(new Action<Cloudcoremodel_SubProcess>(this.attach_Cloudcoremodel_SubProcess), new Action<Cloudcoremodel_SubProcess>(this.detach_Cloudcoremodel_SubProcess));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this.OnProcessRevisionIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevisionId = value;
					this.SendPropertyChanged("ProcessRevisionId");
					this.OnProcessRevisionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					if (this._Cloudcoremodel_ProcessModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessModelIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessModelId = value;
					this.SendPropertyChanged("ProcessModelId");
					this.OnProcessModelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevision", DbType="Int NOT NULL")]
		public int ProcessRevision
		{
			get
			{
				return this._ProcessRevision;
			}
			set
			{
				if ((this._ProcessRevision != value))
				{
					this.OnProcessRevisionChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevision = value;
					this.SendPropertyChanged("ProcessRevision");
					this.OnProcessRevisionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckSum", DbType="VarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string CheckSum
		{
			get
			{
				return this._CheckSum;
			}
			set
			{
				if ((this._CheckSum != value))
				{
					this.OnCheckSumChanging(value);
					this.SendPropertyChanging();
					this._CheckSum = value;
					this.SendPropertyChanged("CheckSum");
					this.OnCheckSumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					if (this._Manager.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnManagerIdChanging(value);
					this.SendPropertyChanging();
					this._ManagerId = value;
					this.SendPropertyChanged("ManagerId");
					this.OnManagerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Changed", DbType="DateTime NOT NULL")]
		public System.DateTime Changed
		{
			get
			{
				return this._Changed;
			}
			set
			{
				if ((this._Changed != value))
				{
					this.OnChangedChanging(value);
					this.SendPropertyChanging();
					this._Changed = value;
					this.SendPropertyChanged("Changed");
					this.OnChangedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_ProcessRevision", Storage="_Cloudcoremodel_ActivityModel", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ActivityModel> Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel;
			}
			set
			{
				this._Cloudcoremodel_ActivityModel.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_FlowModel_ProcessModel", Storage="_Cloudcoremodel_FlowModel", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_FlowModel> Cloudcoremodel_FlowModel
		{
			get
			{
				return this._Cloudcoremodel_FlowModel;
			}
			set
			{
				this._Cloudcoremodel_FlowModel.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_ProcessModel", Storage="_Cloudcoremodel_ProcessModel", ThisKey="ProcessModelId", OtherKey="ProcessModelId", IsForeignKey=true)]
		public Cloudcoremodel_ProcessModel Cloudcoremodel_ProcessModel
		{
			get
			{
				return this._Cloudcoremodel_ProcessModel.Entity;
			}
			set
			{
				Cloudcoremodel_ProcessModel previousValue = this._Cloudcoremodel_ProcessModel.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ProcessModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ProcessModel.Entity = null;
						previousValue.Cloudcoremodel_ProcessRevision.Remove(this);
					}
					this._Cloudcoremodel_ProcessModel.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ProcessRevision.Add(this);
						this._ProcessModelId = value.ProcessModelId;
					}
					else
					{
						this._ProcessModelId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ProcessModel");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcoremodel_ProcessRevision.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_ProcessRevision.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_User_ManagerId", Storage="_Manager", ThisKey="ManagerId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Manager
		{
			get
			{
				return this._Manager.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Manager.Entity;
				if (((previousValue != value) 
							|| (this._Manager.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Manager.Entity = null;
						previousValue.ProcessRevision_User_ManagerId.Remove(this);
					}
					this._Manager.Entity = value;
					if ((value != null))
					{
						value.ProcessRevision_User_ManagerId.Add(this);
						this._ManagerId = value.UserId;
					}
					else
					{
						this._ManagerId = default(int);
					}
					this.SendPropertyChanged("Manager");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SubProcess_ProcessRevision", Storage="_Cloudcoremodel_SubProcess", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_SubProcess> Cloudcoremodel_SubProcess
		{
			get
			{
				return this._Cloudcoremodel_SubProcess;
			}
			set
			{
				this._Cloudcoremodel_SubProcess.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = this;
		}
		
		private void detach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = null;
		}
		
		private void attach_Cloudcoremodel_FlowModel(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = this;
		}
		
		private void detach_Cloudcoremodel_FlowModel(Cloudcoremodel_FlowModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = null;
		}
		
		private void attach_Cloudcoremodel_SubProcess(Cloudcoremodel_SubProcess entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = this;
		}
		
		private void detach_Cloudcoremodel_SubProcess(Cloudcoremodel_SubProcess entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_ProcessRevision = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ReferenceType")]
	public partial class Cloudcore_ReferenceType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ReferenceTypeId;
		
		private string _ReferenceType;
		
		private EntitySet<Cloudcore_WorklistReference> _Cloudcore_WorklistReference;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnReferenceTypeIdChanging(int value);
    partial void OnReferenceTypeIdChanged();
    partial void OnReferenceTypeChanging(string value);
    partial void OnReferenceTypeChanged();
    #endregion
		
		public Cloudcore_ReferenceType()
		{
			this._Cloudcore_WorklistReference = new EntitySet<Cloudcore_WorklistReference>(new Action<Cloudcore_WorklistReference>(this.attach_Cloudcore_WorklistReference), new Action<Cloudcore_WorklistReference>(this.detach_Cloudcore_WorklistReference));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceTypeId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ReferenceTypeId
		{
			get
			{
				return this._ReferenceTypeId;
			}
			set
			{
				if ((this._ReferenceTypeId != value))
				{
					this.OnReferenceTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ReferenceTypeId = value;
					this.SendPropertyChanged("ReferenceTypeId");
					this.OnReferenceTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceType", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string ReferenceType
		{
			get
			{
				return this._ReferenceType;
			}
			set
			{
				if ((this._ReferenceType != value))
				{
					this.OnReferenceTypeChanging(value);
					this.SendPropertyChanging();
					this._ReferenceType = value;
					this.SendPropertyChanged("ReferenceType");
					this.OnReferenceTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistReference_ReferenceType", Storage="_Cloudcore_WorklistReference", ThisKey="ReferenceTypeId", OtherKey="ReferenceTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_WorklistReference> Cloudcore_WorklistReference
		{
			get
			{
				return this._Cloudcore_WorklistReference;
			}
			set
			{
				this._Cloudcore_WorklistReference.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_WorklistReference(Cloudcore_WorklistReference entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ReferenceType = this;
		}
		
		private void detach_Cloudcore_WorklistReference(Cloudcore_WorklistReference entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ReferenceType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ScheduledTask")]
	public partial class Cloudcore_ScheduledTask : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ScheduledTaskId;
		
		private System.Guid _ScheduledTaskGuid;
		
		private string _ScheduledTaskName;
		
		private byte _ScheduledTaskTypeId;
		
		private string _ScheduledTaskType;
		
		private System.DateTime _Created;
		
		private System.Nullable<System.DateTime> _Started;
		
		private byte _StatusId;
		
		private string _Status;
		
		private bool _Active;
		
		private bool _OnDemand;
		
		private byte _IntervalType;
		
		private string _IntervalTypeName;
		
		private int _IntervalValue;
		
		private System.DateTime _InitDate;
		
		private System.DateTime _NextRunDate;
		
		private int _ScheduledTaskGroupId;
		
		private int _SystemModuleId;
		
		private EntityRef<Cloudcore_ScheduledTaskGroup> _Cloudcore_ScheduledTaskGroup;
		
		private EntityRef<Cloudcore_SystemModule> _Cloudcore_SystemModule;
		
		private EntitySet<Cloudcore_ScheduledTaskFailed> _Cloudcore_ScheduledTaskFailed;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnScheduledTaskIdChanging(int value);
    partial void OnScheduledTaskIdChanged();
    partial void OnScheduledTaskGuidChanging(System.Guid value);
    partial void OnScheduledTaskGuidChanged();
    partial void OnScheduledTaskNameChanging(string value);
    partial void OnScheduledTaskNameChanged();
    partial void OnScheduledTaskTypeIdChanging(byte value);
    partial void OnScheduledTaskTypeIdChanged();
    partial void OnScheduledTaskTypeChanging(string value);
    partial void OnScheduledTaskTypeChanged();
    partial void OnCreatedChanging(System.DateTime value);
    partial void OnCreatedChanged();
    partial void OnStartedChanging(System.Nullable<System.DateTime> value);
    partial void OnStartedChanged();
    partial void OnStatusIdChanging(byte value);
    partial void OnStatusIdChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    partial void OnOnDemandChanging(bool value);
    partial void OnOnDemandChanged();
    partial void OnIntervalTypeChanging(byte value);
    partial void OnIntervalTypeChanged();
    partial void OnIntervalTypeNameChanging(string value);
    partial void OnIntervalTypeNameChanged();
    partial void OnIntervalValueChanging(int value);
    partial void OnIntervalValueChanged();
    partial void OnInitDateChanging(System.DateTime value);
    partial void OnInitDateChanged();
    partial void OnNextRunDateChanging(System.DateTime value);
    partial void OnNextRunDateChanged();
    partial void OnScheduledTaskGroupIdChanging(int value);
    partial void OnScheduledTaskGroupIdChanged();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    #endregion
		
		public Cloudcore_ScheduledTask()
		{
			this._Cloudcore_ScheduledTaskGroup = default(EntityRef<Cloudcore_ScheduledTaskGroup>);
			this._Cloudcore_SystemModule = default(EntityRef<Cloudcore_SystemModule>);
			this._Cloudcore_ScheduledTaskFailed = new EntitySet<Cloudcore_ScheduledTaskFailed>(new Action<Cloudcore_ScheduledTaskFailed>(this.attach_Cloudcore_ScheduledTaskFailed), new Action<Cloudcore_ScheduledTaskFailed>(this.detach_Cloudcore_ScheduledTaskFailed));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ScheduledTaskId
		{
			get
			{
				return this._ScheduledTaskId;
			}
			set
			{
				if ((this._ScheduledTaskId != value))
				{
					this.OnScheduledTaskIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskId = value;
					this.SendPropertyChanged("ScheduledTaskId");
					this.OnScheduledTaskIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ScheduledTaskGuid
		{
			get
			{
				return this._ScheduledTaskGuid;
			}
			set
			{
				if ((this._ScheduledTaskGuid != value))
				{
					this.OnScheduledTaskGuidChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskGuid = value;
					this.SendPropertyChanged("ScheduledTaskGuid");
					this.OnScheduledTaskGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ScheduledTaskName
		{
			get
			{
				return this._ScheduledTaskName;
			}
			set
			{
				if ((this._ScheduledTaskName != value))
				{
					this.OnScheduledTaskNameChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskName = value;
					this.SendPropertyChanged("ScheduledTaskName");
					this.OnScheduledTaskNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskTypeId", DbType="TinyInt NOT NULL")]
		public byte ScheduledTaskTypeId
		{
			get
			{
				return this._ScheduledTaskTypeId;
			}
			set
			{
				if ((this._ScheduledTaskTypeId != value))
				{
					this.OnScheduledTaskTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskTypeId = value;
					this.SendPropertyChanged("ScheduledTaskTypeId");
					this.OnScheduledTaskTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskType", AutoSync=AutoSync.Always, DbType="VarChar(7) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [ScheduledTaskTypeId] when (0) then \'Sql\' when (1) then \'CSharp\' else \'Unkn" +
			"own\' end)")]
		public string ScheduledTaskType
		{
			get
			{
				return this._ScheduledTaskType;
			}
			set
			{
				if ((this._ScheduledTaskType != value))
				{
					this.OnScheduledTaskTypeChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskType = value;
					this.SendPropertyChanged("ScheduledTaskType");
					this.OnScheduledTaskTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Started", DbType="DateTime")]
		public System.Nullable<System.DateTime> Started
		{
			get
			{
				return this._Started;
			}
			set
			{
				if ((this._Started != value))
				{
					this.OnStartedChanging(value);
					this.SendPropertyChanging();
					this._Started = value;
					this.SendPropertyChanged("Started");
					this.OnStartedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusId", DbType="TinyInt NOT NULL")]
		public byte StatusId
		{
			get
			{
				return this._StatusId;
			}
			set
			{
				if ((this._StatusId != value))
				{
					this.OnStatusIdChanging(value);
					this.SendPropertyChanging();
					this._StatusId = value;
					this.SendPropertyChanged("StatusId");
					this.OnStatusIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", AutoSync=AutoSync.Always, DbType="VarChar(9) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [StatusId] when (0) then \'Scheduled\' when (1) then \'Running\' when (101) the" +
			"n \'Failed\' when (100) then \'Disabled\' else \'Unknown\' end)")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OnDemand", DbType="Bit NOT NULL")]
		public bool OnDemand
		{
			get
			{
				return this._OnDemand;
			}
			set
			{
				if ((this._OnDemand != value))
				{
					this.OnOnDemandChanging(value);
					this.SendPropertyChanging();
					this._OnDemand = value;
					this.SendPropertyChanged("OnDemand");
					this.OnOnDemandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntervalType", DbType="TinyInt NOT NULL")]
		public byte IntervalType
		{
			get
			{
				return this._IntervalType;
			}
			set
			{
				if ((this._IntervalType != value))
				{
					this.OnIntervalTypeChanging(value);
					this.SendPropertyChanging();
					this._IntervalType = value;
					this.SendPropertyChanged("IntervalType");
					this.OnIntervalTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntervalTypeName", AutoSync=AutoSync.Always, DbType="VarChar(7) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [IntervalType] when (0) then \'Years\' when (1) then \'Months\' when (2) then \'" +
			"Weeks\' when (3) then \'Days\' when (4) then \'Hours\' when (5) then \'Mintues\' when (" +
			"6) then \'Seconds\' else \'Days\' end)")]
		public string IntervalTypeName
		{
			get
			{
				return this._IntervalTypeName;
			}
			set
			{
				if ((this._IntervalTypeName != value))
				{
					this.OnIntervalTypeNameChanging(value);
					this.SendPropertyChanging();
					this._IntervalTypeName = value;
					this.SendPropertyChanged("IntervalTypeName");
					this.OnIntervalTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntervalValue", DbType="Int NOT NULL")]
		public int IntervalValue
		{
			get
			{
				return this._IntervalValue;
			}
			set
			{
				if ((this._IntervalValue != value))
				{
					this.OnIntervalValueChanging(value);
					this.SendPropertyChanging();
					this._IntervalValue = value;
					this.SendPropertyChanged("IntervalValue");
					this.OnIntervalValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InitDate", DbType="DateTime NOT NULL")]
		public System.DateTime InitDate
		{
			get
			{
				return this._InitDate;
			}
			set
			{
				if ((this._InitDate != value))
				{
					this.OnInitDateChanging(value);
					this.SendPropertyChanging();
					this._InitDate = value;
					this.SendPropertyChanged("InitDate");
					this.OnInitDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NextRunDate", DbType="DateTime NOT NULL")]
		public System.DateTime NextRunDate
		{
			get
			{
				return this._NextRunDate;
			}
			set
			{
				if ((this._NextRunDate != value))
				{
					this.OnNextRunDateChanging(value);
					this.SendPropertyChanging();
					this._NextRunDate = value;
					this.SendPropertyChanged("NextRunDate");
					this.OnNextRunDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGroupId", DbType="Int NOT NULL")]
		public int ScheduledTaskGroupId
		{
			get
			{
				return this._ScheduledTaskGroupId;
			}
			set
			{
				if ((this._ScheduledTaskGroupId != value))
				{
					if (this._Cloudcore_ScheduledTaskGroup.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnScheduledTaskGroupIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskGroupId = value;
					this.SendPropertyChanged("ScheduledTaskGroupId");
					this.OnScheduledTaskGroupIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					if (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTask_ScheduledTaskGroup", Storage="_Cloudcore_ScheduledTaskGroup", ThisKey="ScheduledTaskGroupId", OtherKey="ScheduledTaskGroupId", IsForeignKey=true)]
		public Cloudcore_ScheduledTaskGroup Cloudcore_ScheduledTaskGroup
		{
			get
			{
				return this._Cloudcore_ScheduledTaskGroup.Entity;
			}
			set
			{
				Cloudcore_ScheduledTaskGroup previousValue = this._Cloudcore_ScheduledTaskGroup.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_ScheduledTaskGroup.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_ScheduledTaskGroup.Entity = null;
						previousValue.Cloudcore_ScheduledTask.Remove(this);
					}
					this._Cloudcore_ScheduledTaskGroup.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ScheduledTask.Add(this);
						this._ScheduledTaskGroupId = value.ScheduledTaskGroupId;
					}
					else
					{
						this._ScheduledTaskGroupId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_ScheduledTaskGroup");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTask_SystemModule", Storage="_Cloudcore_SystemModule", ThisKey="SystemModuleId", OtherKey="SystemModuleId", IsForeignKey=true)]
		public Cloudcore_SystemModule Cloudcore_SystemModule
		{
			get
			{
				return this._Cloudcore_SystemModule.Entity;
			}
			set
			{
				Cloudcore_SystemModule previousValue = this._Cloudcore_SystemModule.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemModule.Entity = null;
						previousValue.Cloudcore_ScheduledTask.Remove(this);
					}
					this._Cloudcore_SystemModule.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ScheduledTask.Add(this);
						this._SystemModuleId = value.SystemModuleId;
					}
					else
					{
						this._SystemModuleId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemModule");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskFailed_ScheduledTask", Storage="_Cloudcore_ScheduledTaskFailed", ThisKey="ScheduledTaskId", OtherKey="ScheduledTaskId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ScheduledTaskFailed> Cloudcore_ScheduledTaskFailed
		{
			get
			{
				return this._Cloudcore_ScheduledTaskFailed;
			}
			set
			{
				this._Cloudcore_ScheduledTaskFailed.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ScheduledTaskFailed(Cloudcore_ScheduledTaskFailed entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ScheduledTask = this;
		}
		
		private void detach_Cloudcore_ScheduledTaskFailed(Cloudcore_ScheduledTaskFailed entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ScheduledTask = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ScheduledTaskFailed")]
	public partial class Cloudcore_ScheduledTaskFailed : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ScheduledTaskFailedId;
		
		private int _ScheduledTaskId;
		
		private System.DateTime _FailedAt;
		
		private string _Reason;
		
		private EntityRef<Cloudcore_ScheduledTask> _Cloudcore_ScheduledTask;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnScheduledTaskFailedIdChanging(long value);
    partial void OnScheduledTaskFailedIdChanged();
    partial void OnScheduledTaskIdChanging(int value);
    partial void OnScheduledTaskIdChanged();
    partial void OnFailedAtChanging(System.DateTime value);
    partial void OnFailedAtChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    #endregion
		
		public Cloudcore_ScheduledTaskFailed()
		{
			this._Cloudcore_ScheduledTask = default(EntityRef<Cloudcore_ScheduledTask>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskFailedId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ScheduledTaskFailedId
		{
			get
			{
				return this._ScheduledTaskFailedId;
			}
			set
			{
				if ((this._ScheduledTaskFailedId != value))
				{
					this.OnScheduledTaskFailedIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskFailedId = value;
					this.SendPropertyChanged("ScheduledTaskFailedId");
					this.OnScheduledTaskFailedIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskId", DbType="Int NOT NULL")]
		public int ScheduledTaskId
		{
			get
			{
				return this._ScheduledTaskId;
			}
			set
			{
				if ((this._ScheduledTaskId != value))
				{
					if (this._Cloudcore_ScheduledTask.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnScheduledTaskIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskId = value;
					this.SendPropertyChanged("ScheduledTaskId");
					this.OnScheduledTaskIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FailedAt", DbType="DateTime NOT NULL")]
		public System.DateTime FailedAt
		{
			get
			{
				return this._FailedAt;
			}
			set
			{
				if ((this._FailedAt != value))
				{
					this.OnFailedAtChanging(value);
					this.SendPropertyChanging();
					this._FailedAt = value;
					this.SendPropertyChanged("FailedAt");
					this.OnFailedAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this.OnReasonChanging(value);
					this.SendPropertyChanging();
					this._Reason = value;
					this.SendPropertyChanged("Reason");
					this.OnReasonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskFailed_ScheduledTask", Storage="_Cloudcore_ScheduledTask", ThisKey="ScheduledTaskId", OtherKey="ScheduledTaskId", IsForeignKey=true)]
		public Cloudcore_ScheduledTask Cloudcore_ScheduledTask
		{
			get
			{
				return this._Cloudcore_ScheduledTask.Entity;
			}
			set
			{
				Cloudcore_ScheduledTask previousValue = this._Cloudcore_ScheduledTask.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_ScheduledTask.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_ScheduledTask.Entity = null;
						previousValue.Cloudcore_ScheduledTaskFailed.Remove(this);
					}
					this._Cloudcore_ScheduledTask.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ScheduledTaskFailed.Add(this);
						this._ScheduledTaskId = value.ScheduledTaskId;
					}
					else
					{
						this._ScheduledTaskId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_ScheduledTask");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.ScheduledTaskGroup")]
	public partial class Cloudcore_ScheduledTaskGroup : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ScheduledTaskGroupId;
		
		private System.Guid _ScheduledTaskGroupGuid;
		
		private int _SystemModuleId;
		
		private string _ScheduledTaskGroupName;
		
		private int _ManagerUserId;
		
		private EntitySet<Cloudcore_ScheduledTask> _Cloudcore_ScheduledTask;
		
		private EntityRef<Cloudcore_SystemModule> _Cloudcore_SystemModule;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnScheduledTaskGroupIdChanging(int value);
    partial void OnScheduledTaskGroupIdChanged();
    partial void OnScheduledTaskGroupGuidChanging(System.Guid value);
    partial void OnScheduledTaskGroupGuidChanged();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    partial void OnScheduledTaskGroupNameChanging(string value);
    partial void OnScheduledTaskGroupNameChanged();
    partial void OnManagerUserIdChanging(int value);
    partial void OnManagerUserIdChanged();
    #endregion
		
		public Cloudcore_ScheduledTaskGroup()
		{
			this._Cloudcore_ScheduledTask = new EntitySet<Cloudcore_ScheduledTask>(new Action<Cloudcore_ScheduledTask>(this.attach_Cloudcore_ScheduledTask), new Action<Cloudcore_ScheduledTask>(this.detach_Cloudcore_ScheduledTask));
			this._Cloudcore_SystemModule = default(EntityRef<Cloudcore_SystemModule>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGroupId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ScheduledTaskGroupId
		{
			get
			{
				return this._ScheduledTaskGroupId;
			}
			set
			{
				if ((this._ScheduledTaskGroupId != value))
				{
					this.OnScheduledTaskGroupIdChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskGroupId = value;
					this.SendPropertyChanged("ScheduledTaskGroupId");
					this.OnScheduledTaskGroupIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGroupGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ScheduledTaskGroupGuid
		{
			get
			{
				return this._ScheduledTaskGroupGuid;
			}
			set
			{
				if ((this._ScheduledTaskGroupGuid != value))
				{
					this.OnScheduledTaskGroupGuidChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskGroupGuid = value;
					this.SendPropertyChanged("ScheduledTaskGroupGuid");
					this.OnScheduledTaskGroupGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					if (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGroupName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ScheduledTaskGroupName
		{
			get
			{
				return this._ScheduledTaskGroupName;
			}
			set
			{
				if ((this._ScheduledTaskGroupName != value))
				{
					this.OnScheduledTaskGroupNameChanging(value);
					this.SendPropertyChanging();
					this._ScheduledTaskGroupName = value;
					this.SendPropertyChanged("ScheduledTaskGroupName");
					this.OnScheduledTaskGroupNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerUserId", DbType="Int NOT NULL")]
		public int ManagerUserId
		{
			get
			{
				return this._ManagerUserId;
			}
			set
			{
				if ((this._ManagerUserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnManagerUserIdChanging(value);
					this.SendPropertyChanging();
					this._ManagerUserId = value;
					this.SendPropertyChanged("ManagerUserId");
					this.OnManagerUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTask_ScheduledTaskGroup", Storage="_Cloudcore_ScheduledTask", ThisKey="ScheduledTaskGroupId", OtherKey="ScheduledTaskGroupId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ScheduledTask> Cloudcore_ScheduledTask
		{
			get
			{
				return this._Cloudcore_ScheduledTask;
			}
			set
			{
				this._Cloudcore_ScheduledTask.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskGroup_SystemModule", Storage="_Cloudcore_SystemModule", ThisKey="SystemModuleId", OtherKey="SystemModuleId", IsForeignKey=true)]
		public Cloudcore_SystemModule Cloudcore_SystemModule
		{
			get
			{
				return this._Cloudcore_SystemModule.Entity;
			}
			set
			{
				Cloudcore_SystemModule previousValue = this._Cloudcore_SystemModule.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemModule.Entity = null;
						previousValue.Cloudcore_ScheduledTaskGroup.Remove(this);
					}
					this._Cloudcore_SystemModule.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ScheduledTaskGroup.Add(this);
						this._SystemModuleId = value.SystemModuleId;
					}
					else
					{
						this._SystemModuleId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemModule");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskGroup_User", Storage="_Cloudcore_User", ThisKey="ManagerUserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_ScheduledTaskGroup.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_ScheduledTaskGroup.Add(this);
						this._ManagerUserId = value.UserId;
					}
					else
					{
						this._ManagerUserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ScheduledTask(Cloudcore_ScheduledTask entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ScheduledTaskGroup = this;
		}
		
		private void detach_Cloudcore_ScheduledTask(Cloudcore_ScheduledTask entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_ScheduledTaskGroup = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.StatusType")]
	public partial class Cloudcoremodel_StatusType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _StatusTypeId;
		
		private string _StatusTypeName;
		
		private EntitySet<Cloudcore_ActivityHistory> _Cloudcore_ActivityHistory;
		
		private EntitySet<Cloudcore_Worklist> _Cloudcore_Worklist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStatusTypeIdChanging(byte value);
    partial void OnStatusTypeIdChanged();
    partial void OnStatusTypeNameChanging(string value);
    partial void OnStatusTypeNameChanged();
    #endregion
		
		public Cloudcoremodel_StatusType()
		{
			this._Cloudcore_ActivityHistory = new EntitySet<Cloudcore_ActivityHistory>(new Action<Cloudcore_ActivityHistory>(this.attach_Cloudcore_ActivityHistory), new Action<Cloudcore_ActivityHistory>(this.detach_Cloudcore_ActivityHistory));
			this._Cloudcore_Worklist = new EntitySet<Cloudcore_Worklist>(new Action<Cloudcore_Worklist>(this.attach_Cloudcore_Worklist), new Action<Cloudcore_Worklist>(this.detach_Cloudcore_Worklist));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL", IsPrimaryKey=true)]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					this.OnStatusTypeIdChanging(value);
					this.SendPropertyChanging();
					this._StatusTypeId = value;
					this.SendPropertyChanged("StatusTypeId");
					this.OnStatusTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string StatusTypeName
		{
			get
			{
				return this._StatusTypeName;
			}
			set
			{
				if ((this._StatusTypeName != value))
				{
					this.OnStatusTypeNameChanging(value);
					this.SendPropertyChanging();
					this._StatusTypeName = value;
					this.SendPropertyChanged("StatusTypeName");
					this.OnStatusTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_StatusType", Storage="_Cloudcore_ActivityHistory", ThisKey="StatusTypeId", OtherKey="StatusTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityHistory> Cloudcore_ActivityHistory
		{
			get
			{
				return this._Cloudcore_ActivityHistory;
			}
			set
			{
				this._Cloudcore_ActivityHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_StatusType", Storage="_Cloudcore_Worklist", ThisKey="StatusTypeId", OtherKey="StatusTypeId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Worklist> Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist;
			}
			set
			{
				this._Cloudcore_Worklist.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_StatusType = this;
		}
		
		private void detach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_StatusType = null;
		}
		
		private void attach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_StatusType = this;
		}
		
		private void detach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_StatusType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.SubProcess")]
	public partial class Cloudcoremodel_SubProcess : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SubProcessId;
		
		private int _ProcessRevisionId;
		
		private System.Guid _SubProcessGuid;
		
		private string _SubProcessName;
		
		private EntitySet<Cloudcoremodel_ActivityModel> _Cloudcoremodel_ActivityModel;
		
		private EntityRef<Cloudcoremodel_ProcessRevision> _Cloudcoremodel_ProcessRevision;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSubProcessIdChanging(int value);
    partial void OnSubProcessIdChanged();
    partial void OnProcessRevisionIdChanging(int value);
    partial void OnProcessRevisionIdChanged();
    partial void OnSubProcessGuidChanging(System.Guid value);
    partial void OnSubProcessGuidChanged();
    partial void OnSubProcessNameChanging(string value);
    partial void OnSubProcessNameChanged();
    #endregion
		
		public Cloudcoremodel_SubProcess()
		{
			this._Cloudcoremodel_ActivityModel = new EntitySet<Cloudcoremodel_ActivityModel>(new Action<Cloudcoremodel_ActivityModel>(this.attach_Cloudcoremodel_ActivityModel), new Action<Cloudcoremodel_ActivityModel>(this.detach_Cloudcoremodel_ActivityModel));
			this._Cloudcoremodel_ProcessRevision = default(EntityRef<Cloudcoremodel_ProcessRevision>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this.OnSubProcessIdChanging(value);
					this.SendPropertyChanging();
					this._SubProcessId = value;
					this.SendPropertyChanged("SubProcessId");
					this.OnSubProcessIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					if (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProcessRevisionIdChanging(value);
					this.SendPropertyChanging();
					this._ProcessRevisionId = value;
					this.SendPropertyChanged("ProcessRevisionId");
					this.OnProcessRevisionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this.OnSubProcessGuidChanging(value);
					this.SendPropertyChanging();
					this._SubProcessGuid = value;
					this.SendPropertyChanged("SubProcessGuid");
					this.OnSubProcessGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this.OnSubProcessNameChanging(value);
					this.SendPropertyChanging();
					this._SubProcessName = value;
					this.SendPropertyChanged("SubProcessName");
					this.OnSubProcessNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityModel_SubProcess", Storage="_Cloudcoremodel_ActivityModel", ThisKey="SubProcessId", OtherKey="SubProcessId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ActivityModel> Cloudcoremodel_ActivityModel
		{
			get
			{
				return this._Cloudcoremodel_ActivityModel;
			}
			set
			{
				this._Cloudcoremodel_ActivityModel.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SubProcess_ProcessRevision", Storage="_Cloudcoremodel_ProcessRevision", ThisKey="ProcessRevisionId", OtherKey="ProcessRevisionId", IsForeignKey=true)]
		public Cloudcoremodel_ProcessRevision Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this._Cloudcoremodel_ProcessRevision.Entity;
			}
			set
			{
				Cloudcoremodel_ProcessRevision previousValue = this._Cloudcoremodel_ProcessRevision.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_ProcessRevision.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_ProcessRevision.Entity = null;
						previousValue.Cloudcoremodel_SubProcess.Remove(this);
					}
					this._Cloudcoremodel_ProcessRevision.Entity = value;
					if ((value != null))
					{
						value.Cloudcoremodel_SubProcess.Add(this);
						this._ProcessRevisionId = value.ProcessRevisionId;
					}
					else
					{
						this._ProcessRevisionId = default(int);
					}
					this.SendPropertyChanged("Cloudcoremodel_ProcessRevision");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_SubProcess = this;
		}
		
		private void detach_Cloudcoremodel_ActivityModel(Cloudcoremodel_ActivityModel entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcoremodel_SubProcess = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemAction")]
	public partial class Cloudcore_SystemAction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActionId;
		
		private System.Guid _ActionGuid;
		
		private int _SystemModuleId;
		
		private string _ActionType;
		
		private string _ActionTitle;
		
		private string _Area;
		
		private string _Controller;
		
		private string _Action;
		
		private EntityRef<Cloudcore_SystemModule> _Cloudcore_SystemModule;
		
		private EntitySet<Cloudcore_SystemActionAllocation> _Cloudcore_SystemActionAllocation;
		
		private EntitySet<Cloudcore_SystemMenu> _Cloudcore_SystemMenu;
		
		private EntitySet<Cloudcore_SystemMenu> _SystemMenu_SystemAction2;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActionIdChanging(int value);
    partial void OnActionIdChanged();
    partial void OnActionGuidChanging(System.Guid value);
    partial void OnActionGuidChanged();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    partial void OnActionTypeChanging(string value);
    partial void OnActionTypeChanged();
    partial void OnActionTitleChanging(string value);
    partial void OnActionTitleChanged();
    partial void OnAreaChanging(string value);
    partial void OnAreaChanged();
    partial void OnControllerChanging(string value);
    partial void OnControllerChanged();
    partial void OnActionChanging(string value);
    partial void OnActionChanged();
    #endregion
		
		public Cloudcore_SystemAction()
		{
			this._Cloudcore_SystemModule = default(EntityRef<Cloudcore_SystemModule>);
			this._Cloudcore_SystemActionAllocation = new EntitySet<Cloudcore_SystemActionAllocation>(new Action<Cloudcore_SystemActionAllocation>(this.attach_Cloudcore_SystemActionAllocation), new Action<Cloudcore_SystemActionAllocation>(this.detach_Cloudcore_SystemActionAllocation));
			this._Cloudcore_SystemMenu = new EntitySet<Cloudcore_SystemMenu>(new Action<Cloudcore_SystemMenu>(this.attach_Cloudcore_SystemMenu), new Action<Cloudcore_SystemMenu>(this.detach_Cloudcore_SystemMenu));
			this._SystemMenu_SystemAction2 = new EntitySet<Cloudcore_SystemMenu>(new Action<Cloudcore_SystemMenu>(this.attach_SystemMenu_SystemAction2), new Action<Cloudcore_SystemMenu>(this.detach_SystemMenu_SystemAction2));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ActionId
		{
			get
			{
				return this._ActionId;
			}
			set
			{
				if ((this._ActionId != value))
				{
					this.OnActionIdChanging(value);
					this.SendPropertyChanging();
					this._ActionId = value;
					this.SendPropertyChanged("ActionId");
					this.OnActionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActionGuid
		{
			get
			{
				return this._ActionGuid;
			}
			set
			{
				if ((this._ActionGuid != value))
				{
					this.OnActionGuidChanging(value);
					this.SendPropertyChanging();
					this._ActionGuid = value;
					this.SendPropertyChanged("ActionGuid");
					this.OnActionGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					if (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionType", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ActionType
		{
			get
			{
				return this._ActionType;
			}
			set
			{
				if ((this._ActionType != value))
				{
					this.OnActionTypeChanging(value);
					this.SendPropertyChanging();
					this._ActionType = value;
					this.SendPropertyChanged("ActionType");
					this.OnActionTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionTitle", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActionTitle
		{
			get
			{
				return this._ActionTitle;
			}
			set
			{
				if ((this._ActionTitle != value))
				{
					this.OnActionTitleChanging(value);
					this.SendPropertyChanging();
					this._ActionTitle = value;
					this.SendPropertyChanged("ActionTitle");
					this.OnActionTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this.OnAreaChanging(value);
					this.SendPropertyChanging();
					this._Area = value;
					this.SendPropertyChanged("Area");
					this.OnAreaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Controller", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Controller
		{
			get
			{
				return this._Controller;
			}
			set
			{
				if ((this._Controller != value))
				{
					this.OnControllerChanging(value);
					this.SendPropertyChanging();
					this._Controller = value;
					this.SendPropertyChanged("Controller");
					this.OnControllerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Action", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				if ((this._Action != value))
				{
					this.OnActionChanging(value);
					this.SendPropertyChanging();
					this._Action = value;
					this.SendPropertyChanged("Action");
					this.OnActionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemAction_SystemModule", Storage="_Cloudcore_SystemModule", ThisKey="SystemModuleId", OtherKey="SystemModuleId", IsForeignKey=true)]
		public Cloudcore_SystemModule Cloudcore_SystemModule
		{
			get
			{
				return this._Cloudcore_SystemModule.Entity;
			}
			set
			{
				Cloudcore_SystemModule previousValue = this._Cloudcore_SystemModule.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemModule.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemModule.Entity = null;
						previousValue.Cloudcore_SystemAction.Remove(this);
					}
					this._Cloudcore_SystemModule.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemAction.Add(this);
						this._SystemModuleId = value.SystemModuleId;
					}
					else
					{
						this._SystemModuleId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemModule");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemActionAllocation_SystemAction", Storage="_Cloudcore_SystemActionAllocation", ThisKey="ActionId", OtherKey="ActionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemActionAllocation> Cloudcore_SystemActionAllocation
		{
			get
			{
				return this._Cloudcore_SystemActionAllocation;
			}
			set
			{
				this._Cloudcore_SystemActionAllocation.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemMenu_SystemAction", Storage="_Cloudcore_SystemMenu", ThisKey="ActionId", OtherKey="ActionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemMenu> Cloudcore_SystemMenu
		{
			get
			{
				return this._Cloudcore_SystemMenu;
			}
			set
			{
				this._Cloudcore_SystemMenu.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemMenu_SystemAction2", Storage="_SystemMenu_SystemAction2", ThisKey="ActionId", OtherKey="ParentActionId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemMenu> SystemMenu_SystemAction2
		{
			get
			{
				return this._SystemMenu_SystemAction2;
			}
			set
			{
				this._SystemMenu_SystemAction2.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemAction = this;
		}
		
		private void detach_Cloudcore_SystemActionAllocation(Cloudcore_SystemActionAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemAction = null;
		}
		
		private void attach_Cloudcore_SystemMenu(Cloudcore_SystemMenu entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemAction = this;
		}
		
		private void detach_Cloudcore_SystemMenu(Cloudcore_SystemMenu entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemAction = null;
		}
		
		private void attach_SystemMenu_SystemAction2(Cloudcore_SystemMenu entity)
		{
			this.SendPropertyChanging();
			entity.ParentAction = this;
		}
		
		private void detach_SystemMenu_SystemAction2(Cloudcore_SystemMenu entity)
		{
			this.SendPropertyChanging();
			entity.ParentAction = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemActionAllocation")]
	public partial class Cloudcore_SystemActionAllocation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActionId;
		
		private int _AccessPoolId;
		
		private EntityRef<Cloudcore_AccessPool> _Cloudcore_AccessPool;
		
		private EntityRef<Cloudcore_SystemAction> _Cloudcore_SystemAction;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActionIdChanging(int value);
    partial void OnActionIdChanged();
    partial void OnAccessPoolIdChanging(int value);
    partial void OnAccessPoolIdChanged();
    #endregion
		
		public Cloudcore_SystemActionAllocation()
		{
			this._Cloudcore_AccessPool = default(EntityRef<Cloudcore_AccessPool>);
			this._Cloudcore_SystemAction = default(EntityRef<Cloudcore_SystemAction>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ActionId
		{
			get
			{
				return this._ActionId;
			}
			set
			{
				if ((this._ActionId != value))
				{
					if (this._Cloudcore_SystemAction.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActionIdChanging(value);
					this.SendPropertyChanging();
					this._ActionId = value;
					this.SendPropertyChanged("ActionId");
					this.OnActionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					if (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAccessPoolIdChanging(value);
					this.SendPropertyChanging();
					this._AccessPoolId = value;
					this.SendPropertyChanged("AccessPoolId");
					this.OnAccessPoolIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemActionAllocation_AccessRight", Storage="_Cloudcore_AccessPool", ThisKey="AccessPoolId", OtherKey="AccessPoolId", IsForeignKey=true)]
		public Cloudcore_AccessPool Cloudcore_AccessPool
		{
			get
			{
				return this._Cloudcore_AccessPool.Entity;
			}
			set
			{
				Cloudcore_AccessPool previousValue = this._Cloudcore_AccessPool.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_AccessPool.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_AccessPool.Entity = null;
						previousValue.Cloudcore_SystemActionAllocation.Remove(this);
					}
					this._Cloudcore_AccessPool.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemActionAllocation.Add(this);
						this._AccessPoolId = value.AccessPoolId;
					}
					else
					{
						this._AccessPoolId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_AccessPool");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemActionAllocation_SystemAction", Storage="_Cloudcore_SystemAction", ThisKey="ActionId", OtherKey="ActionId", IsForeignKey=true)]
		public Cloudcore_SystemAction Cloudcore_SystemAction
		{
			get
			{
				return this._Cloudcore_SystemAction.Entity;
			}
			set
			{
				Cloudcore_SystemAction previousValue = this._Cloudcore_SystemAction.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemAction.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemAction.Entity = null;
						previousValue.Cloudcore_SystemActionAllocation.Remove(this);
					}
					this._Cloudcore_SystemAction.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemActionAllocation.Add(this);
						this._ActionId = value.ActionId;
					}
					else
					{
						this._ActionId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemAction");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemApplication")]
	public partial class Cloudcore_SystemApplication : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ApplicationId;
		
		private System.Guid _ApplicationGuid;
		
		private string _ApplicationName;
		
		private bool _Enabled;
		
		private string _CompanyName;
		
		private string _PersonName;
		
		private string _ContactNumber;
		
		private EntitySet<Cloudcore_SystemApplicationAllocation> _Cloudcore_SystemApplicationAllocation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(int value);
    partial void OnApplicationIdChanged();
    partial void OnApplicationGuidChanging(System.Guid value);
    partial void OnApplicationGuidChanged();
    partial void OnApplicationNameChanging(string value);
    partial void OnApplicationNameChanged();
    partial void OnEnabledChanging(bool value);
    partial void OnEnabledChanged();
    partial void OnCompanyNameChanging(string value);
    partial void OnCompanyNameChanged();
    partial void OnPersonNameChanging(string value);
    partial void OnPersonNameChanged();
    partial void OnContactNumberChanging(string value);
    partial void OnContactNumberChanged();
    #endregion
		
		public Cloudcore_SystemApplication()
		{
			this._Cloudcore_SystemApplicationAllocation = new EntitySet<Cloudcore_SystemApplicationAllocation>(new Action<Cloudcore_SystemApplicationAllocation>(this.attach_Cloudcore_SystemApplicationAllocation), new Action<Cloudcore_SystemApplicationAllocation>(this.detach_Cloudcore_SystemApplicationAllocation));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ApplicationGuid
		{
			get
			{
				return this._ApplicationGuid;
			}
			set
			{
				if ((this._ApplicationGuid != value))
				{
					this.OnApplicationGuidChanging(value);
					this.SendPropertyChanging();
					this._ApplicationGuid = value;
					this.SendPropertyChanged("ApplicationGuid");
					this.OnApplicationGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string ApplicationName
		{
			get
			{
				return this._ApplicationName;
			}
			set
			{
				if ((this._ApplicationName != value))
				{
					this.OnApplicationNameChanging(value);
					this.SendPropertyChanging();
					this._ApplicationName = value;
					this.SendPropertyChanged("ApplicationName");
					this.OnApplicationNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this.OnEnabledChanging(value);
					this.SendPropertyChanging();
					this._Enabled = value;
					this.SendPropertyChanged("Enabled");
					this.OnEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string CompanyName
		{
			get
			{
				return this._CompanyName;
			}
			set
			{
				if ((this._CompanyName != value))
				{
					this.OnCompanyNameChanging(value);
					this.SendPropertyChanging();
					this._CompanyName = value;
					this.SendPropertyChanged("CompanyName");
					this.OnCompanyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PersonName
		{
			get
			{
				return this._PersonName;
			}
			set
			{
				if ((this._PersonName != value))
				{
					this.OnPersonNameChanging(value);
					this.SendPropertyChanging();
					this._PersonName = value;
					this.SendPropertyChanged("PersonName");
					this.OnPersonNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactNumber", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ContactNumber
		{
			get
			{
				return this._ContactNumber;
			}
			set
			{
				if ((this._ContactNumber != value))
				{
					this.OnContactNumberChanging(value);
					this.SendPropertyChanging();
					this._ContactNumber = value;
					this.SendPropertyChanged("ContactNumber");
					this.OnContactNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemApplicationAllocation_Application", Storage="_Cloudcore_SystemApplicationAllocation", ThisKey="ApplicationId", OtherKey="ApplicationId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemApplicationAllocation> Cloudcore_SystemApplicationAllocation
		{
			get
			{
				return this._Cloudcore_SystemApplicationAllocation;
			}
			set
			{
				this._Cloudcore_SystemApplicationAllocation.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemApplication = this;
		}
		
		private void detach_Cloudcore_SystemApplicationAllocation(Cloudcore_SystemApplicationAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemApplication = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemApplicationAllocation")]
	public partial class Cloudcore_SystemApplicationAllocation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ApplicationId;
		
		private int _ActivityId;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntityRef<Cloudcore_SystemApplication> _Cloudcore_SystemApplication;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(int value);
    partial void OnApplicationIdChanged();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    #endregion
		
		public Cloudcore_SystemApplicationAllocation()
		{
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			this._Cloudcore_SystemApplication = default(EntityRef<Cloudcore_SystemApplication>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					if (this._Cloudcore_SystemApplication.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					if (this._Cloudcore_Activity.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemApplicationAllocation_Activity", Storage="_Cloudcore_Activity", ThisKey="ActivityId", OtherKey="ActivityId", IsForeignKey=true)]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcore_SystemApplicationAllocation.Remove(this);
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemApplicationAllocation.Add(this);
						this._ActivityId = value.ActivityId;
					}
					else
					{
						this._ActivityId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemApplicationAllocation_Application", Storage="_Cloudcore_SystemApplication", ThisKey="ApplicationId", OtherKey="ApplicationId", IsForeignKey=true)]
		public Cloudcore_SystemApplication Cloudcore_SystemApplication
		{
			get
			{
				return this._Cloudcore_SystemApplication.Entity;
			}
			set
			{
				Cloudcore_SystemApplication previousValue = this._Cloudcore_SystemApplication.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemApplication.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemApplication.Entity = null;
						previousValue.Cloudcore_SystemApplicationAllocation.Remove(this);
					}
					this._Cloudcore_SystemApplication.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemApplicationAllocation.Add(this);
						this._ApplicationId = value.ApplicationId;
					}
					else
					{
						this._ApplicationId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemApplication");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemMenu")]
	public partial class Cloudcore_SystemMenu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ActionId;
		
		private int _ParentActionId;
		
		private EntityRef<Cloudcore_SystemAction> _Cloudcore_SystemAction;
		
		private EntityRef<Cloudcore_SystemAction> _ParentAction;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnActionIdChanging(int value);
    partial void OnActionIdChanged();
    partial void OnParentActionIdChanging(int value);
    partial void OnParentActionIdChanged();
    #endregion
		
		public Cloudcore_SystemMenu()
		{
			this._Cloudcore_SystemAction = default(EntityRef<Cloudcore_SystemAction>);
			this._ParentAction = default(EntityRef<Cloudcore_SystemAction>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ActionId
		{
			get
			{
				return this._ActionId;
			}
			set
			{
				if ((this._ActionId != value))
				{
					if (this._Cloudcore_SystemAction.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActionIdChanging(value);
					this.SendPropertyChanging();
					this._ActionId = value;
					this.SendPropertyChanged("ActionId");
					this.OnActionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentActionId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ParentActionId
		{
			get
			{
				return this._ParentActionId;
			}
			set
			{
				if ((this._ParentActionId != value))
				{
					if (this._ParentAction.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentActionIdChanging(value);
					this.SendPropertyChanging();
					this._ParentActionId = value;
					this.SendPropertyChanged("ParentActionId");
					this.OnParentActionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemMenu_SystemAction", Storage="_Cloudcore_SystemAction", ThisKey="ActionId", OtherKey="ActionId", IsForeignKey=true)]
		public Cloudcore_SystemAction Cloudcore_SystemAction
		{
			get
			{
				return this._Cloudcore_SystemAction.Entity;
			}
			set
			{
				Cloudcore_SystemAction previousValue = this._Cloudcore_SystemAction.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemAction.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemAction.Entity = null;
						previousValue.Cloudcore_SystemMenu.Remove(this);
					}
					this._Cloudcore_SystemAction.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemMenu.Add(this);
						this._ActionId = value.ActionId;
					}
					else
					{
						this._ActionId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemAction");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemMenu_SystemAction2", Storage="_ParentAction", ThisKey="ParentActionId", OtherKey="ActionId", IsForeignKey=true)]
		public Cloudcore_SystemAction ParentAction
		{
			get
			{
				return this._ParentAction.Entity;
			}
			set
			{
				Cloudcore_SystemAction previousValue = this._ParentAction.Entity;
				if (((previousValue != value) 
							|| (this._ParentAction.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ParentAction.Entity = null;
						previousValue.SystemMenu_SystemAction2.Remove(this);
					}
					this._ParentAction.Entity = value;
					if ((value != null))
					{
						value.SystemMenu_SystemAction2.Add(this);
						this._ParentActionId = value.ActionId;
					}
					else
					{
						this._ParentActionId = default(int);
					}
					this.SendPropertyChanged("ParentAction");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemModule")]
	public partial class Cloudcore_SystemModule : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SystemModuleId;
		
		private string _AssemblyName;
		
		private string _DefaultNamespace;
		
		private byte _ModuleTypeId;
		
		private string _ModuleType;
		
		private bool _Enabled;
		
		private EntitySet<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntitySet<Cloudcore_Dashboard> _Cloudcore_Dashboard;
		
		private EntitySet<Cloudcore_ScheduledTask> _Cloudcore_ScheduledTask;
		
		private EntitySet<Cloudcore_ScheduledTaskGroup> _Cloudcore_ScheduledTaskGroup;
		
		private EntitySet<Cloudcore_SystemAction> _Cloudcore_SystemAction;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSystemModuleIdChanging(int value);
    partial void OnSystemModuleIdChanged();
    partial void OnAssemblyNameChanging(string value);
    partial void OnAssemblyNameChanged();
    partial void OnDefaultNamespaceChanging(string value);
    partial void OnDefaultNamespaceChanged();
    partial void OnModuleTypeIdChanging(byte value);
    partial void OnModuleTypeIdChanged();
    partial void OnModuleTypeChanging(string value);
    partial void OnModuleTypeChanged();
    partial void OnEnabledChanging(bool value);
    partial void OnEnabledChanged();
    #endregion
		
		public Cloudcore_SystemModule()
		{
			this._Cloudcore_Activity = new EntitySet<Cloudcore_Activity>(new Action<Cloudcore_Activity>(this.attach_Cloudcore_Activity), new Action<Cloudcore_Activity>(this.detach_Cloudcore_Activity));
			this._Cloudcore_Dashboard = new EntitySet<Cloudcore_Dashboard>(new Action<Cloudcore_Dashboard>(this.attach_Cloudcore_Dashboard), new Action<Cloudcore_Dashboard>(this.detach_Cloudcore_Dashboard));
			this._Cloudcore_ScheduledTask = new EntitySet<Cloudcore_ScheduledTask>(new Action<Cloudcore_ScheduledTask>(this.attach_Cloudcore_ScheduledTask), new Action<Cloudcore_ScheduledTask>(this.detach_Cloudcore_ScheduledTask));
			this._Cloudcore_ScheduledTaskGroup = new EntitySet<Cloudcore_ScheduledTaskGroup>(new Action<Cloudcore_ScheduledTaskGroup>(this.attach_Cloudcore_ScheduledTaskGroup), new Action<Cloudcore_ScheduledTaskGroup>(this.detach_Cloudcore_ScheduledTaskGroup));
			this._Cloudcore_SystemAction = new EntitySet<Cloudcore_SystemAction>(new Action<Cloudcore_SystemAction>(this.attach_Cloudcore_SystemAction), new Action<Cloudcore_SystemAction>(this.detach_Cloudcore_SystemAction));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					this.OnSystemModuleIdChanging(value);
					this.SendPropertyChanging();
					this._SystemModuleId = value;
					this.SendPropertyChanged("SystemModuleId");
					this.OnSystemModuleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssemblyName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AssemblyName
		{
			get
			{
				return this._AssemblyName;
			}
			set
			{
				if ((this._AssemblyName != value))
				{
					this.OnAssemblyNameChanging(value);
					this.SendPropertyChanging();
					this._AssemblyName = value;
					this.SendPropertyChanged("AssemblyName");
					this.OnAssemblyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultNamespace", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string DefaultNamespace
		{
			get
			{
				return this._DefaultNamespace;
			}
			set
			{
				if ((this._DefaultNamespace != value))
				{
					this.OnDefaultNamespaceChanging(value);
					this.SendPropertyChanging();
					this._DefaultNamespace = value;
					this.SendPropertyChanged("DefaultNamespace");
					this.OnDefaultNamespaceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModuleTypeId", DbType="TinyInt NOT NULL")]
		public byte ModuleTypeId
		{
			get
			{
				return this._ModuleTypeId;
			}
			set
			{
				if ((this._ModuleTypeId != value))
				{
					this.OnModuleTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ModuleTypeId = value;
					this.SendPropertyChanged("ModuleTypeId");
					this.OnModuleTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModuleType", AutoSync=AutoSync.Always, DbType="VarChar(11) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case [ModuleTypeId] when (0) then \'Web\' when (1) then \'Process\' when (2) then \'C" +
			"ore\' when (3) then \'Data\' when (4) then \'Service API\' else \'Unknown\' end)")]
		public string ModuleType
		{
			get
			{
				return this._ModuleType;
			}
			set
			{
				if ((this._ModuleType != value))
				{
					this.OnModuleTypeChanging(value);
					this.SendPropertyChanging();
					this._ModuleType = value;
					this.SendPropertyChanged("ModuleType");
					this.OnModuleTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this.OnEnabledChanging(value);
					this.SendPropertyChanging();
					this._Enabled = value;
					this.SendPropertyChanged("Enabled");
					this.OnEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Activity_SystemModule", Storage="_Cloudcore_Activity", ThisKey="SystemModuleId", OtherKey="SystemModuleId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Activity> Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity;
			}
			set
			{
				this._Cloudcore_Activity.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Dashboard_SystemModule", Storage="_Cloudcore_Dashboard", ThisKey="SystemModuleId", OtherKey="SystemModuleId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Dashboard> Cloudcore_Dashboard
		{
			get
			{
				return this._Cloudcore_Dashboard;
			}
			set
			{
				this._Cloudcore_Dashboard.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTask_SystemModule", Storage="_Cloudcore_ScheduledTask", ThisKey="SystemModuleId", OtherKey="SystemModuleId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ScheduledTask> Cloudcore_ScheduledTask
		{
			get
			{
				return this._Cloudcore_ScheduledTask;
			}
			set
			{
				this._Cloudcore_ScheduledTask.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskGroup_SystemModule", Storage="_Cloudcore_ScheduledTaskGroup", ThisKey="SystemModuleId", OtherKey="SystemModuleId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ScheduledTaskGroup> Cloudcore_ScheduledTaskGroup
		{
			get
			{
				return this._Cloudcore_ScheduledTaskGroup;
			}
			set
			{
				this._Cloudcore_ScheduledTaskGroup.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemAction_SystemModule", Storage="_Cloudcore_SystemAction", ThisKey="SystemModuleId", OtherKey="SystemModuleId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemAction> Cloudcore_SystemAction
		{
			get
			{
				return this._Cloudcore_SystemAction;
			}
			set
			{
				this._Cloudcore_SystemAction.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_Activity(Cloudcore_Activity entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = this;
		}
		
		private void detach_Cloudcore_Activity(Cloudcore_Activity entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = null;
		}
		
		private void attach_Cloudcore_Dashboard(Cloudcore_Dashboard entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = this;
		}
		
		private void detach_Cloudcore_Dashboard(Cloudcore_Dashboard entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = null;
		}
		
		private void attach_Cloudcore_ScheduledTask(Cloudcore_ScheduledTask entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = this;
		}
		
		private void detach_Cloudcore_ScheduledTask(Cloudcore_ScheduledTask entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = null;
		}
		
		private void attach_Cloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = this;
		}
		
		private void detach_Cloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = null;
		}
		
		private void attach_Cloudcore_SystemAction(Cloudcore_SystemAction entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = this;
		}
		
		private void detach_Cloudcore_SystemAction(Cloudcore_SystemAction entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemModule = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemTally")]
	public partial class Cloudcore_SystemTally : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TallyId;
		
		private int _ZeroBased;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTallyIdChanging(int value);
    partial void OnTallyIdChanged();
    partial void OnZeroBasedChanging(int value);
    partial void OnZeroBasedChanged();
    #endregion
		
		public Cloudcore_SystemTally()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TallyId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TallyId
		{
			get
			{
				return this._TallyId;
			}
			set
			{
				if ((this._TallyId != value))
				{
					this.OnTallyIdChanging(value);
					this.SendPropertyChanging();
					this._TallyId = value;
					this.SendPropertyChanged("TallyId");
					this.OnTallyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZeroBased", DbType="Int NOT NULL")]
		public int ZeroBased
		{
			get
			{
				return this._ZeroBased;
			}
			set
			{
				if ((this._ZeroBased != value))
				{
					this.OnZeroBasedChanging(value);
					this.SendPropertyChanging();
					this._ZeroBased = value;
					this.SendPropertyChanged("ZeroBased");
					this.OnZeroBasedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemValue")]
	public partial class Cloudcore_SystemValue : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ValueID;
		
		private int _CategoryId;
		
		private string _ValueName;
		
		private string _ValueData;
		
		private string _ValueDescription;
		
		private EntityRef<Cloudcore_SystemValueCategory> _Cloudcore_SystemValueCategory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnValueIDChanging(int value);
    partial void OnValueIDChanged();
    partial void OnCategoryIdChanging(int value);
    partial void OnCategoryIdChanged();
    partial void OnValueNameChanging(string value);
    partial void OnValueNameChanged();
    partial void OnValueDataChanging(string value);
    partial void OnValueDataChanged();
    partial void OnValueDescriptionChanging(string value);
    partial void OnValueDescriptionChanged();
    #endregion
		
		public Cloudcore_SystemValue()
		{
			this._Cloudcore_SystemValueCategory = default(EntityRef<Cloudcore_SystemValueCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValueID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ValueID
		{
			get
			{
				return this._ValueID;
			}
			set
			{
				if ((this._ValueID != value))
				{
					this.OnValueIDChanging(value);
					this.SendPropertyChanging();
					this._ValueID = value;
					this.SendPropertyChanged("ValueID");
					this.OnValueIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", DbType="Int NOT NULL")]
		public int CategoryId
		{
			get
			{
				return this._CategoryId;
			}
			set
			{
				if ((this._CategoryId != value))
				{
					if (this._Cloudcore_SystemValueCategory.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCategoryIdChanging(value);
					this.SendPropertyChanging();
					this._CategoryId = value;
					this.SendPropertyChanged("CategoryId");
					this.OnCategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValueName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ValueName
		{
			get
			{
				return this._ValueName;
			}
			set
			{
				if ((this._ValueName != value))
				{
					this.OnValueNameChanging(value);
					this.SendPropertyChanging();
					this._ValueName = value;
					this.SendPropertyChanged("ValueName");
					this.OnValueNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValueData", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string ValueData
		{
			get
			{
				return this._ValueData;
			}
			set
			{
				if ((this._ValueData != value))
				{
					this.OnValueDataChanging(value);
					this.SendPropertyChanging();
					this._ValueData = value;
					this.SendPropertyChanged("ValueData");
					this.OnValueDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValueDescription", DbType="VarChar(8000) NOT NULL", CanBeNull=false)]
		public string ValueDescription
		{
			get
			{
				return this._ValueDescription;
			}
			set
			{
				if ((this._ValueDescription != value))
				{
					this.OnValueDescriptionChanging(value);
					this.SendPropertyChanging();
					this._ValueDescription = value;
					this.SendPropertyChanged("ValueDescription");
					this.OnValueDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemValue_SystemValueCategory", Storage="_Cloudcore_SystemValueCategory", ThisKey="CategoryId", OtherKey="CategoryId", IsForeignKey=true)]
		public Cloudcore_SystemValueCategory Cloudcore_SystemValueCategory
		{
			get
			{
				return this._Cloudcore_SystemValueCategory.Entity;
			}
			set
			{
				Cloudcore_SystemValueCategory previousValue = this._Cloudcore_SystemValueCategory.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_SystemValueCategory.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_SystemValueCategory.Entity = null;
						previousValue.Cloudcore_SystemValue.Remove(this);
					}
					this._Cloudcore_SystemValueCategory.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_SystemValue.Add(this);
						this._CategoryId = value.CategoryId;
					}
					else
					{
						this._CategoryId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_SystemValueCategory");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.SystemValueCategory")]
	public partial class Cloudcore_SystemValueCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CategoryId;
		
		private string _CategoryName;
		
		private EntitySet<Cloudcore_SystemValue> _Cloudcore_SystemValue;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCategoryIdChanging(int value);
    partial void OnCategoryIdChanged();
    partial void OnCategoryNameChanging(string value);
    partial void OnCategoryNameChanged();
    #endregion
		
		public Cloudcore_SystemValueCategory()
		{
			this._Cloudcore_SystemValue = new EntitySet<Cloudcore_SystemValue>(new Action<Cloudcore_SystemValue>(this.attach_Cloudcore_SystemValue), new Action<Cloudcore_SystemValue>(this.detach_Cloudcore_SystemValue));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CategoryId
		{
			get
			{
				return this._CategoryId;
			}
			set
			{
				if ((this._CategoryId != value))
				{
					this.OnCategoryIdChanging(value);
					this.SendPropertyChanging();
					this._CategoryId = value;
					this.SendPropertyChanged("CategoryId");
					this.OnCategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				if ((this._CategoryName != value))
				{
					this.OnCategoryNameChanging(value);
					this.SendPropertyChanging();
					this._CategoryName = value;
					this.SendPropertyChanged("CategoryName");
					this.OnCategoryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_SystemValue_SystemValueCategory", Storage="_Cloudcore_SystemValue", ThisKey="CategoryId", OtherKey="CategoryId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_SystemValue> Cloudcore_SystemValue
		{
			get
			{
				return this._Cloudcore_SystemValue;
			}
			set
			{
				this._Cloudcore_SystemValue.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_SystemValue(Cloudcore_SystemValue entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemValueCategory = this;
		}
		
		private void detach_Cloudcore_SystemValue(Cloudcore_SystemValue entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_SystemValueCategory = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.User")]
	public partial class Cloudcore_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private System.Guid _UserKey;
		
		private string _Login;
		
		private string _Account;
		
		private string _Initials;
		
		private string _Preferredname;
		
		private string _Firstnames;
		
		private string _Surname;
		
		private string _PasswordHash;
		
		private System.DateTime _PasswordChanged;
		
		private string _Email;
		
		private string _CellNo;
		
		private int _Active;
		
		private bool _IntAccess;
		
		private bool _ExtAccess;
		
		private bool _IsNamedUser;
		
		private System.DateTime _Created;
		
		private System.Data.Linq.Binary _ThumbImage;
		
		private System.Data.Linq.Binary _MainImage;
		
		private string _Fullname;
		
		private string _NFullname;
		
		private EntitySet<Cloudcore_AccessPoolUser> _Cloudcore_AccessPoolUser;
		
		private EntitySet<Cloudcore_WorklistFailure> _Cloudcore_WorklistFailure;
		
		private EntitySet<Cloudcore_ActivityFailureHistory> _Cloudcore_ActivityFailureHistory;
		
		private EntitySet<Cloudcore_ActivityHistory> _Cloudcore_ActivityHistory;
		
		private EntitySet<Cloudcore_Campaign> _Cloudcore_Campaign;
		
		private EntitySet<Cloudcore_CampaignArchive> _Cloudcore_CampaignArchive;
		
		private EntitySet<Cloudcore_CampaignUser> _Cloudcore_CampaignUser;
		
		private EntitySet<Cloudcore_DashboardUserAllocation> _Cloudcore_DashboardUserAllocation;
		
		private EntitySet<Cloudcore_Favourite> _Cloudcore_Favourite;
		
		private EntitySet<Cloudcore_LoginHistory> _Cloudcore_LoginHistory;
		
		private EntitySet<Cloudcore_Notification> _Cloudcore_Notification;
		
		private EntitySet<Cloudcore_ScheduledTaskGroup> _Cloudcore_ScheduledTaskGroup;
		
		private EntitySet<Cloudcore_UserAccessMapping> _Cloudcore_UserAccessMapping;
		
		private EntitySet<Cloudcore_Worklist> _Cloudcore_Worklist;
		
		private EntitySet<Cloudcore_Worklist> _User;
		
		private EntitySet<Cloudcoremodel_ProcessRevision> _Cloudcoremodel_ProcessRevision;
		
		private EntitySet<Cloudcoremodel_ProcessRevision> _ProcessRevision_User_ManagerId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUserKeyChanging(System.Guid value);
    partial void OnUserKeyChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnAccountChanging(string value);
    partial void OnAccountChanged();
    partial void OnInitialsChanging(string value);
    partial void OnInitialsChanged();
    partial void OnPreferrednameChanging(string value);
    partial void OnPreferrednameChanged();
    partial void OnFirstnamesChanging(string value);
    partial void OnFirstnamesChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnPasswordHashChanging(string value);
    partial void OnPasswordHashChanged();
    partial void OnPasswordChangedChanging(System.DateTime value);
    partial void OnPasswordChangedChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnCellNoChanging(string value);
    partial void OnCellNoChanged();
    partial void OnActiveChanging(int value);
    partial void OnActiveChanged();
    partial void OnIntAccessChanging(bool value);
    partial void OnIntAccessChanged();
    partial void OnExtAccessChanging(bool value);
    partial void OnExtAccessChanged();
    partial void OnIsNamedUserChanging(bool value);
    partial void OnIsNamedUserChanged();
    partial void OnCreatedChanging(System.DateTime value);
    partial void OnCreatedChanged();
    partial void OnThumbImageChanging(System.Data.Linq.Binary value);
    partial void OnThumbImageChanged();
    partial void OnMainImageChanging(System.Data.Linq.Binary value);
    partial void OnMainImageChanged();
    partial void OnFullnameChanging(string value);
    partial void OnFullnameChanged();
    partial void OnNFullnameChanging(string value);
    partial void OnNFullnameChanged();
    #endregion
		
		public Cloudcore_User()
		{
			this._Cloudcore_AccessPoolUser = new EntitySet<Cloudcore_AccessPoolUser>(new Action<Cloudcore_AccessPoolUser>(this.attach_Cloudcore_AccessPoolUser), new Action<Cloudcore_AccessPoolUser>(this.detach_Cloudcore_AccessPoolUser));
			this._Cloudcore_WorklistFailure = new EntitySet<Cloudcore_WorklistFailure>(new Action<Cloudcore_WorklistFailure>(this.attach_Cloudcore_WorklistFailure), new Action<Cloudcore_WorklistFailure>(this.detach_Cloudcore_WorklistFailure));
			this._Cloudcore_ActivityFailureHistory = new EntitySet<Cloudcore_ActivityFailureHistory>(new Action<Cloudcore_ActivityFailureHistory>(this.attach_Cloudcore_ActivityFailureHistory), new Action<Cloudcore_ActivityFailureHistory>(this.detach_Cloudcore_ActivityFailureHistory));
			this._Cloudcore_ActivityHistory = new EntitySet<Cloudcore_ActivityHistory>(new Action<Cloudcore_ActivityHistory>(this.attach_Cloudcore_ActivityHistory), new Action<Cloudcore_ActivityHistory>(this.detach_Cloudcore_ActivityHistory));
			this._Cloudcore_Campaign = new EntitySet<Cloudcore_Campaign>(new Action<Cloudcore_Campaign>(this.attach_Cloudcore_Campaign), new Action<Cloudcore_Campaign>(this.detach_Cloudcore_Campaign));
			this._Cloudcore_CampaignArchive = new EntitySet<Cloudcore_CampaignArchive>(new Action<Cloudcore_CampaignArchive>(this.attach_Cloudcore_CampaignArchive), new Action<Cloudcore_CampaignArchive>(this.detach_Cloudcore_CampaignArchive));
			this._Cloudcore_CampaignUser = new EntitySet<Cloudcore_CampaignUser>(new Action<Cloudcore_CampaignUser>(this.attach_Cloudcore_CampaignUser), new Action<Cloudcore_CampaignUser>(this.detach_Cloudcore_CampaignUser));
			this._Cloudcore_DashboardUserAllocation = new EntitySet<Cloudcore_DashboardUserAllocation>(new Action<Cloudcore_DashboardUserAllocation>(this.attach_Cloudcore_DashboardUserAllocation), new Action<Cloudcore_DashboardUserAllocation>(this.detach_Cloudcore_DashboardUserAllocation));
			this._Cloudcore_Favourite = new EntitySet<Cloudcore_Favourite>(new Action<Cloudcore_Favourite>(this.attach_Cloudcore_Favourite), new Action<Cloudcore_Favourite>(this.detach_Cloudcore_Favourite));
			this._Cloudcore_LoginHistory = new EntitySet<Cloudcore_LoginHistory>(new Action<Cloudcore_LoginHistory>(this.attach_Cloudcore_LoginHistory), new Action<Cloudcore_LoginHistory>(this.detach_Cloudcore_LoginHistory));
			this._Cloudcore_Notification = new EntitySet<Cloudcore_Notification>(new Action<Cloudcore_Notification>(this.attach_Cloudcore_Notification), new Action<Cloudcore_Notification>(this.detach_Cloudcore_Notification));
			this._Cloudcore_ScheduledTaskGroup = new EntitySet<Cloudcore_ScheduledTaskGroup>(new Action<Cloudcore_ScheduledTaskGroup>(this.attach_Cloudcore_ScheduledTaskGroup), new Action<Cloudcore_ScheduledTaskGroup>(this.detach_Cloudcore_ScheduledTaskGroup));
			this._Cloudcore_UserAccessMapping = new EntitySet<Cloudcore_UserAccessMapping>(new Action<Cloudcore_UserAccessMapping>(this.attach_Cloudcore_UserAccessMapping), new Action<Cloudcore_UserAccessMapping>(this.detach_Cloudcore_UserAccessMapping));
			this._Cloudcore_Worklist = new EntitySet<Cloudcore_Worklist>(new Action<Cloudcore_Worklist>(this.attach_Cloudcore_Worklist), new Action<Cloudcore_Worklist>(this.detach_Cloudcore_Worklist));
			this._User = new EntitySet<Cloudcore_Worklist>(new Action<Cloudcore_Worklist>(this.attach_User), new Action<Cloudcore_Worklist>(this.detach_User));
			this._Cloudcoremodel_ProcessRevision = new EntitySet<Cloudcoremodel_ProcessRevision>(new Action<Cloudcoremodel_ProcessRevision>(this.attach_Cloudcoremodel_ProcessRevision), new Action<Cloudcoremodel_ProcessRevision>(this.detach_Cloudcoremodel_ProcessRevision));
			this._ProcessRevision_User_ManagerId = new EntitySet<Cloudcoremodel_ProcessRevision>(new Action<Cloudcoremodel_ProcessRevision>(this.attach_ProcessRevision_User_ManagerId), new Action<Cloudcoremodel_ProcessRevision>(this.detach_ProcessRevision_User_ManagerId));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserKey", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserKey
		{
			get
			{
				return this._UserKey;
			}
			set
			{
				if ((this._UserKey != value))
				{
					this.OnUserKeyChanging(value);
					this.SendPropertyChanging();
					this._UserKey = value;
					this.SendPropertyChanged("UserKey");
					this.OnUserKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="VarChar(320) NOT NULL", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Account
		{
			get
			{
				return this._Account;
			}
			set
			{
				if ((this._Account != value))
				{
					this.OnAccountChanging(value);
					this.SendPropertyChanging();
					this._Account = value;
					this.SendPropertyChanged("Account");
					this.OnAccountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Initials", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string Initials
		{
			get
			{
				return this._Initials;
			}
			set
			{
				if ((this._Initials != value))
				{
					this.OnInitialsChanging(value);
					this.SendPropertyChanging();
					this._Initials = value;
					this.SendPropertyChanged("Initials");
					this.OnInitialsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Preferredname", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string Preferredname
		{
			get
			{
				return this._Preferredname;
			}
			set
			{
				if ((this._Preferredname != value))
				{
					this.OnPreferrednameChanging(value);
					this.SendPropertyChanging();
					this._Preferredname = value;
					this.SendPropertyChanged("Preferredname");
					this.OnPreferrednameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Firstnames", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Firstnames
		{
			get
			{
				return this._Firstnames;
			}
			set
			{
				if ((this._Firstnames != value))
				{
					this.OnFirstnamesChanging(value);
					this.SendPropertyChanging();
					this._Firstnames = value;
					this.SendPropertyChanged("Firstnames");
					this.OnFirstnamesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordHash", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PasswordHash
		{
			get
			{
				return this._PasswordHash;
			}
			set
			{
				if ((this._PasswordHash != value))
				{
					this.OnPasswordHashChanging(value);
					this.SendPropertyChanging();
					this._PasswordHash = value;
					this.SendPropertyChanged("PasswordHash");
					this.OnPasswordHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordChanged", DbType="DateTime NOT NULL")]
		public System.DateTime PasswordChanged
		{
			get
			{
				return this._PasswordChanged;
			}
			set
			{
				if ((this._PasswordChanged != value))
				{
					this.OnPasswordChangedChanging(value);
					this.SendPropertyChanging();
					this._PasswordChanged = value;
					this.SendPropertyChanged("PasswordChanged");
					this.OnPasswordChangedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CellNo", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string CellNo
		{
			get
			{
				return this._CellNo;
			}
			set
			{
				if ((this._CellNo != value))
				{
					this.OnCellNoChanging(value);
					this.SendPropertyChanging();
					this._CellNo = value;
					this.SendPropertyChanged("CellNo");
					this.OnCellNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", AutoSync=AutoSync.Always, DbType="Int NOT NULL", IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(case when [IntAccess]=(1) OR [ExtAccess]=(1) then (1) else (0) end)")]
		public int Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntAccess", DbType="Bit NOT NULL")]
		public bool IntAccess
		{
			get
			{
				return this._IntAccess;
			}
			set
			{
				if ((this._IntAccess != value))
				{
					this.OnIntAccessChanging(value);
					this.SendPropertyChanging();
					this._IntAccess = value;
					this.SendPropertyChanged("IntAccess");
					this.OnIntAccessChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExtAccess", DbType="Bit NOT NULL")]
		public bool ExtAccess
		{
			get
			{
				return this._ExtAccess;
			}
			set
			{
				if ((this._ExtAccess != value))
				{
					this.OnExtAccessChanging(value);
					this.SendPropertyChanging();
					this._ExtAccess = value;
					this.SendPropertyChanged("ExtAccess");
					this.OnExtAccessChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsNamedUser", DbType="Bit NOT NULL")]
		public bool IsNamedUser
		{
			get
			{
				return this._IsNamedUser;
			}
			set
			{
				if ((this._IsNamedUser != value))
				{
					this.OnIsNamedUserChanging(value);
					this.SendPropertyChanging();
					this._IsNamedUser = value;
					this.SendPropertyChanged("IsNamedUser");
					this.OnIsNamedUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThumbImage", DbType="Image", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary ThumbImage
		{
			get
			{
				return this._ThumbImage;
			}
			set
			{
				if ((this._ThumbImage != value))
				{
					this.OnThumbImageChanging(value);
					this.SendPropertyChanging();
					this._ThumbImage = value;
					this.SendPropertyChanged("ThumbImage");
					this.OnThumbImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MainImage", DbType="Image", CanBeNull=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary MainImage
		{
			get
			{
				return this._MainImage;
			}
			set
			{
				if ((this._MainImage != value))
				{
					this.OnMainImageChanging(value);
					this.SendPropertyChanging();
					this._MainImage = value;
					this.SendPropertyChanged("MainImage");
					this.OnMainImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fullname", AutoSync=AutoSync.Always, DbType="VarChar(131) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(([Firstnames]+\' \')+[Surname])")]
		public string Fullname
		{
			get
			{
				return this._Fullname;
			}
			set
			{
				if ((this._Fullname != value))
				{
					this.OnFullnameChanging(value);
					this.SendPropertyChanging();
					this._Fullname = value;
					this.SendPropertyChanged("Fullname");
					this.OnFullnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NFullname", AutoSync=AutoSync.Always, DbType="VarChar(71) NOT NULL", CanBeNull=false, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(([Preferredname]+\' \')+[Surname])")]
		public string NFullname
		{
			get
			{
				return this._NFullname;
			}
			set
			{
				if ((this._NFullname != value))
				{
					this.OnNFullnameChanging(value);
					this.SendPropertyChanging();
					this._NFullname = value;
					this.SendPropertyChanged("NFullname");
					this.OnNFullnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_AccessPoolUser_User", Storage="_Cloudcore_AccessPoolUser", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_AccessPoolUser> Cloudcore_AccessPoolUser
		{
			get
			{
				return this._Cloudcore_AccessPoolUser;
			}
			set
			{
				this._Cloudcore_AccessPoolUser.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailed_User", Storage="_Cloudcore_WorklistFailure", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_WorklistFailure> Cloudcore_WorklistFailure
		{
			get
			{
				return this._Cloudcore_WorklistFailure;
			}
			set
			{
				this._Cloudcore_WorklistFailure.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailureHistory_User", Storage="_Cloudcore_ActivityFailureHistory", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityFailureHistory> Cloudcore_ActivityFailureHistory
		{
			get
			{
				return this._Cloudcore_ActivityFailureHistory;
			}
			set
			{
				this._Cloudcore_ActivityFailureHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityHistory_User", Storage="_Cloudcore_ActivityHistory", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ActivityHistory> Cloudcore_ActivityHistory
		{
			get
			{
				return this._Cloudcore_ActivityHistory;
			}
			set
			{
				this._Cloudcore_ActivityHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Campaign_User", Storage="_Cloudcore_Campaign", ThisKey="UserId", OtherKey="ManagerId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Campaign> Cloudcore_Campaign
		{
			get
			{
				return this._Cloudcore_Campaign;
			}
			set
			{
				this._Cloudcore_Campaign.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignArchive_User", Storage="_Cloudcore_CampaignArchive", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignArchive> Cloudcore_CampaignArchive
		{
			get
			{
				return this._Cloudcore_CampaignArchive;
			}
			set
			{
				this._Cloudcore_CampaignArchive.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignUser_User", Storage="_Cloudcore_CampaignUser", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignUser> Cloudcore_CampaignUser
		{
			get
			{
				return this._Cloudcore_CampaignUser;
			}
			set
			{
				this._Cloudcore_CampaignUser.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_DashboardUserAllocation_User", Storage="_Cloudcore_DashboardUserAllocation", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_DashboardUserAllocation> Cloudcore_DashboardUserAllocation
		{
			get
			{
				return this._Cloudcore_DashboardUserAllocation;
			}
			set
			{
				this._Cloudcore_DashboardUserAllocation.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Favourite_User", Storage="_Cloudcore_Favourite", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Favourite> Cloudcore_Favourite
		{
			get
			{
				return this._Cloudcore_Favourite;
			}
			set
			{
				this._Cloudcore_Favourite.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_LoginHistory_User", Storage="_Cloudcore_LoginHistory", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_LoginHistory> Cloudcore_LoginHistory
		{
			get
			{
				return this._Cloudcore_LoginHistory;
			}
			set
			{
				this._Cloudcore_LoginHistory.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Notification_Creator", Storage="_Cloudcore_Notification", ThisKey="UserId", OtherKey="Creator", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Notification> Cloudcore_Notification
		{
			get
			{
				return this._Cloudcore_Notification;
			}
			set
			{
				this._Cloudcore_Notification.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ScheduledTaskGroup_User", Storage="_Cloudcore_ScheduledTaskGroup", ThisKey="UserId", OtherKey="ManagerUserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_ScheduledTaskGroup> Cloudcore_ScheduledTaskGroup
		{
			get
			{
				return this._Cloudcore_ScheduledTaskGroup;
			}
			set
			{
				this._Cloudcore_ScheduledTaskGroup.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_UserAccessMapping_User", Storage="_Cloudcore_UserAccessMapping", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_UserAccessMapping> Cloudcore_UserAccessMapping
		{
			get
			{
				return this._Cloudcore_UserAccessMapping;
			}
			set
			{
				this._Cloudcore_UserAccessMapping.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_OpenedBy", Storage="_Cloudcore_Worklist", ThisKey="UserId", OtherKey="OpenedBy", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Worklist> Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist;
			}
			set
			{
				this._Cloudcore_Worklist.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_User_UserId", Storage="_User", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_Worklist> User
		{
			get
			{
				return this._User;
			}
			set
			{
				this._User.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_User", Storage="_Cloudcoremodel_ProcessRevision", ThisKey="UserId", OtherKey="UserId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ProcessRevision> Cloudcoremodel_ProcessRevision
		{
			get
			{
				return this._Cloudcoremodel_ProcessRevision;
			}
			set
			{
				this._Cloudcoremodel_ProcessRevision.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ProcessRevision_User_ManagerId", Storage="_ProcessRevision_User_ManagerId", ThisKey="UserId", OtherKey="ManagerId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcoremodel_ProcessRevision> ProcessRevision_User_ManagerId
		{
			get
			{
				return this._ProcessRevision_User_ManagerId;
			}
			set
			{
				this._ProcessRevision_User_ManagerId.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_AccessPoolUser(Cloudcore_AccessPoolUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_AccessPoolUser(Cloudcore_AccessPoolUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_WorklistFailure(Cloudcore_WorklistFailure entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_WorklistFailure(Cloudcore_WorklistFailure entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_ActivityFailureHistory(Cloudcore_ActivityFailureHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_ActivityHistory(Cloudcore_ActivityHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_Campaign(Cloudcore_Campaign entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_Campaign(Cloudcore_Campaign entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_CampaignArchive(Cloudcore_CampaignArchive entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_CampaignArchive(Cloudcore_CampaignArchive entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_CampaignUser(Cloudcore_CampaignUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_CampaignUser(Cloudcore_CampaignUser entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_DashboardUserAllocation(Cloudcore_DashboardUserAllocation entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_Favourite(Cloudcore_Favourite entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_Favourite(Cloudcore_Favourite entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_LoginHistory(Cloudcore_LoginHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_LoginHistory(Cloudcore_LoginHistory entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_Notification(Cloudcore_Notification entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_Notification(Cloudcore_Notification entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_ScheduledTaskGroup(Cloudcore_ScheduledTaskGroup entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_UserAccessMapping(Cloudcore_UserAccessMapping entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_UserAccessMapping(Cloudcore_UserAccessMapping entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcore_Worklist(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_User(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_User(Cloudcore_Worklist entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
		
		private void attach_Cloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = this;
		}
		
		private void detach_Cloudcoremodel_ProcessRevision(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_User = null;
		}
		
		private void attach_ProcessRevision_User_ManagerId(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Manager = this;
		}
		
		private void detach_ProcessRevision_User_ManagerId(Cloudcoremodel_ProcessRevision entity)
		{
			this.SendPropertyChanging();
			entity.Manager = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.UserAccessMapping")]
	public partial class Cloudcore_UserAccessMapping : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private int _ProviderId;
		
		private string _UserKey;
		
		private EntityRef<Cloudcore_UserAccessProvider> _Cloudcore_UserAccessProvider;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnProviderIdChanging(int value);
    partial void OnProviderIdChanged();
    partial void OnUserKeyChanging(string value);
    partial void OnUserKeyChanged();
    #endregion
		
		public Cloudcore_UserAccessMapping()
		{
			this._Cloudcore_UserAccessProvider = default(EntityRef<Cloudcore_UserAccessProvider>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProviderId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ProviderId
		{
			get
			{
				return this._ProviderId;
			}
			set
			{
				if ((this._ProviderId != value))
				{
					if (this._Cloudcore_UserAccessProvider.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProviderIdChanging(value);
					this.SendPropertyChanging();
					this._ProviderId = value;
					this.SendPropertyChanged("ProviderId");
					this.OnProviderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserKey", DbType="VarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserKey
		{
			get
			{
				return this._UserKey;
			}
			set
			{
				if ((this._UserKey != value))
				{
					this.OnUserKeyChanging(value);
					this.SendPropertyChanging();
					this._UserKey = value;
					this.SendPropertyChanged("UserKey");
					this.OnUserKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_UserAccessMapping_Provider", Storage="_Cloudcore_UserAccessProvider", ThisKey="ProviderId", OtherKey="ProviderId", IsForeignKey=true)]
		public Cloudcore_UserAccessProvider Cloudcore_UserAccessProvider
		{
			get
			{
				return this._Cloudcore_UserAccessProvider.Entity;
			}
			set
			{
				Cloudcore_UserAccessProvider previousValue = this._Cloudcore_UserAccessProvider.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_UserAccessProvider.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_UserAccessProvider.Entity = null;
						previousValue.Cloudcore_UserAccessMapping.Remove(this);
					}
					this._Cloudcore_UserAccessProvider.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_UserAccessMapping.Add(this);
						this._ProviderId = value.ProviderId;
					}
					else
					{
						this._ProviderId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_UserAccessProvider");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_UserAccessMapping_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_UserAccessMapping.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_UserAccessMapping.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.UserAccessProvider")]
	public partial class Cloudcore_UserAccessProvider : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProviderId;
		
		private string _ProviderName;
		
		private EntitySet<Cloudcore_UserAccessMapping> _Cloudcore_UserAccessMapping;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProviderIdChanging(int value);
    partial void OnProviderIdChanged();
    partial void OnProviderNameChanging(string value);
    partial void OnProviderNameChanged();
    #endregion
		
		public Cloudcore_UserAccessProvider()
		{
			this._Cloudcore_UserAccessMapping = new EntitySet<Cloudcore_UserAccessMapping>(new Action<Cloudcore_UserAccessMapping>(this.attach_Cloudcore_UserAccessMapping), new Action<Cloudcore_UserAccessMapping>(this.detach_Cloudcore_UserAccessMapping));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProviderId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProviderId
		{
			get
			{
				return this._ProviderId;
			}
			set
			{
				if ((this._ProviderId != value))
				{
					this.OnProviderIdChanging(value);
					this.SendPropertyChanging();
					this._ProviderId = value;
					this.SendPropertyChanged("ProviderId");
					this.OnProviderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProviderName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string ProviderName
		{
			get
			{
				return this._ProviderName;
			}
			set
			{
				if ((this._ProviderName != value))
				{
					this.OnProviderNameChanging(value);
					this.SendPropertyChanging();
					this._ProviderName = value;
					this.SendPropertyChanged("ProviderName");
					this.OnProviderNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_UserAccessMapping_Provider", Storage="_Cloudcore_UserAccessMapping", ThisKey="ProviderId", OtherKey="ProviderId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_UserAccessMapping> Cloudcore_UserAccessMapping
		{
			get
			{
				return this._Cloudcore_UserAccessMapping;
			}
			set
			{
				this._Cloudcore_UserAccessMapping.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_UserAccessMapping(Cloudcore_UserAccessMapping entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_UserAccessProvider = this;
		}
		
		private void detach_Cloudcore_UserAccessMapping(Cloudcore_UserAccessMapping entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_UserAccessProvider = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.UserNotification")]
	public partial class Cloudcore_UserNotification : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private int _NotificationId;
		
		private bool _HasRead;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnNotificationIdChanging(int value);
    partial void OnNotificationIdChanged();
    partial void OnHasReadChanging(bool value);
    partial void OnHasReadChanged();
    #endregion
		
		public Cloudcore_UserNotification()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificationId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int NotificationId
		{
			get
			{
				return this._NotificationId;
			}
			set
			{
				if ((this._NotificationId != value))
				{
					this.OnNotificationIdChanging(value);
					this.SendPropertyChanging();
					this._NotificationId = value;
					this.SendPropertyChanged("NotificationId");
					this.OnNotificationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasRead", DbType="Bit NOT NULL")]
		public bool HasRead
		{
			get
			{
				return this._HasRead;
			}
			set
			{
				if ((this._HasRead != value))
				{
					this.OnHasReadChanging(value);
					this.SendPropertyChanging();
					this._HasRead = value;
					this.SendPropertyChanged("HasRead");
					this.OnHasReadChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwAccessPool")]
	public partial class Cloudcore_VwAccessPool
	{
		
		private int _UserId;
		
		private int _AccessPoolId;
		
		private string _AccessPoolName;
		
		private string _Fullname;
		
		public Cloudcore_VwAccessPool()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolId", DbType="Int NOT NULL")]
		public int AccessPoolId
		{
			get
			{
				return this._AccessPoolId;
			}
			set
			{
				if ((this._AccessPoolId != value))
				{
					this._AccessPoolId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessPoolName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AccessPoolName
		{
			get
			{
				return this._AccessPoolName;
			}
			set
			{
				if ((this._AccessPoolName != value))
				{
					this._AccessPoolName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fullname", DbType="VarChar(131) NOT NULL", CanBeNull=false)]
		public string Fullname
		{
			get
			{
				return this._Fullname;
			}
			set
			{
				if ((this._Fullname != value))
				{
					this._Fullname = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwActivityAllocationPriority")]
	public partial class Cloudcore_VwActivityAllocationPriority
	{
		
		private int _UserId;
		
		private int _ActivityId;
		
		private System.Guid _ProcessGuid;
		
		private System.Guid _ActivityGuid;
		
		private System.Guid _SubProcessGuid;
		
		private byte _ActivityTypeId;
		
		private string _ProcessName;
		
		private string _SubProcessName;
		
		private string _ActivityName;
		
		public Cloudcore_VwActivityAllocationPriority()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this._ProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this._SubProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCampaign")]
	public partial class Cloudcore_VwCampaign
	{
		
		private long _InstanceId;
		
		private int _SubProcessId;
		
		private int _ProcessModelId;
		
		private byte _StatusTypeId;
		
		private System.Nullable<bool> _Delayed;
		
		private int _UserId;
		
		private System.DateTime _Activate;
		
		private byte _Priority;
		
		private long _KeyValue;
		
		private System.DateTime _Created;
		
		private string _SubProcessName;
		
		private string _ActivityName;
		
		private int _ActivityId;
		
		private string _ListType;
		
		private bool _DocWait;
		
		private int _CampaignID;
		
		public Cloudcore_VwCampaign()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					this._StatusTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Delayed", DbType="Bit")]
		public System.Nullable<bool> Delayed
		{
			get
			{
				return this._Delayed;
			}
			set
			{
				if ((this._Delayed != value))
				{
					this._Delayed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this._Activate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this._KeyValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListType", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string ListType
		{
			get
			{
				return this._ListType;
			}
			set
			{
				if ((this._ListType != value))
				{
					this._ListType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL")]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this._CampaignID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCampaignDailyStats")]
	public partial class Cloudcore_VwCampaignDailyStats
	{
		
		private System.Nullable<int> _Completed;
		
		private System.Nullable<System.DateTime> _Finished;
		
		private int _CampaignID;
		
		public Cloudcore_VwCampaignDailyStats()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Completed", DbType="Int")]
		public System.Nullable<int> Completed
		{
			get
			{
				return this._Completed;
			}
			set
			{
				if ((this._Completed != value))
				{
					this._Completed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finished", DbType="Date")]
		public System.Nullable<System.DateTime> Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				if ((this._Finished != value))
				{
					this._Finished = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL")]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this._CampaignID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCampaignManager")]
	public partial class Cloudcore_VwCampaignManager
	{
		
		private int _CampaignID;
		
		private string _CampaignName;
		
		private string _CampaignDesc;
		
		private short _StatusID;
		
		private int _ManagerId;
		
		public Cloudcore_VwCampaignManager()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL IDENTITY")]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this._CampaignID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CampaignName
		{
			get
			{
				return this._CampaignName;
			}
			set
			{
				if ((this._CampaignName != value))
				{
					this._CampaignName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignDesc", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string CampaignDesc
		{
			get
			{
				return this._CampaignDesc;
			}
			set
			{
				if ((this._CampaignDesc != value))
				{
					this._CampaignDesc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusID", DbType="SmallInt NOT NULL")]
		public short StatusID
		{
			get
			{
				return this._StatusID;
			}
			set
			{
				if ((this._StatusID != value))
				{
					this._StatusID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					this._ManagerId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCampaignStats")]
	public partial class Cloudcore_VwCampaignStats
	{
		
		private int _CampaignID;
		
		private string _Status;
		
		private System.Nullable<int> _Cnt;
		
		public Cloudcore_VwCampaignStats()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL")]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this._CampaignID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(11) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cnt", DbType="Int")]
		public System.Nullable<int> Cnt
		{
			get
			{
				return this._Cnt;
			}
			set
			{
				if ((this._Cnt != value))
				{
					this._Cnt = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCampaignUserStats")]
	public partial class Cloudcore_VwCampaignUserStats
	{
		
		private System.Nullable<int> _Completed;
		
		private System.Nullable<System.DateTime> _Finished;
		
		private int _UserId;
		
		private int _CampaignID;
		
		public Cloudcore_VwCampaignUserStats()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Completed", DbType="Int")]
		public System.Nullable<int> Completed
		{
			get
			{
				return this._Completed;
			}
			set
			{
				if ((this._Completed != value))
				{
					this._Completed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finished", DbType="Date")]
		public System.Nullable<System.DateTime> Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				if ((this._Finished != value))
				{
					this._Finished = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CampaignID", DbType="Int NOT NULL")]
		public int CampaignID
		{
			get
			{
				return this._CampaignID;
			}
			set
			{
				if ((this._CampaignID != value))
				{
					this._CampaignID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwCostLedger")]
	public partial class Cloudcore_VwCostLedger
	{
		
		private long _LedgerID;
		
		private System.DateTime _TransDate;
		
		private decimal _Cost;
		
		private int _ProcessModelId;
		
		private string _ProcessName;
		
		private int _SubProcessId;
		
		private string _SubProcessName;
		
		public Cloudcore_VwCostLedger()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LedgerID", DbType="BigInt NOT NULL")]
		public long LedgerID
		{
			get
			{
				return this._LedgerID;
			}
			set
			{
				if ((this._LedgerID != value))
				{
					this._LedgerID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransDate
		{
			get
			{
				return this._TransDate;
			}
			set
			{
				if ((this._TransDate != value))
				{
					this._TransDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost", DbType="Money NOT NULL")]
		public decimal Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				if ((this._Cost != value))
				{
					this._Cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwLedgerInfo")]
	public partial class Cloudcore_VwLedgerInfo
	{
		
		private long _LedgerID;
		
		private long _InstanceId;
		
		private int _ActivityModelId;
		
		private decimal _Cost;
		
		private System.DateTime _TransDate;
		
		private int _PeriodSeq;
		
		private bool _Exported;
		
		public Cloudcore_VwLedgerInfo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LedgerID", DbType="BigInt NOT NULL IDENTITY")]
		public long LedgerID
		{
			get
			{
				return this._LedgerID;
			}
			set
			{
				if ((this._LedgerID != value))
				{
					this._LedgerID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost", DbType="Money NOT NULL")]
		public decimal Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				if ((this._Cost != value))
				{
					this._Cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransDate
		{
			get
			{
				return this._TransDate;
			}
			set
			{
				if ((this._TransDate != value))
				{
					this._TransDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PeriodSeq", DbType="Int NOT NULL")]
		public int PeriodSeq
		{
			get
			{
				return this._PeriodSeq;
			}
			set
			{
				if ((this._PeriodSeq != value))
				{
					this._PeriodSeq = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Exported", DbType="Bit NOT NULL")]
		public bool Exported
		{
			get
			{
				return this._Exported;
			}
			set
			{
				if ((this._Exported != value))
				{
					this._Exported = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.vwLiveActivity")]
	public partial class Cloudcoremodel_VwLiveActivity
	{
		
		private int _ActivityId;
		
		private int _ActivityModelId;
		
		private byte _ActivityTypeId;
		
		private string _ActivityTypeName;
		
		private string _ActivityName;
		
		private bool _Startable;
		
		private int _Priority;
		
		private bool _DocWait;
		
		private System.Guid _ActivityGuid;
		
		private int _SystemModuleId;
		
		private string _SystemAssemblyName;
		
		private int _SubProcessId;
		
		private int _ProcessRevisionId;
		
		private string _SubProcessName;
		
		public Cloudcoremodel_VwLiveActivity()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this._ActivityTypeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Startable", DbType="Bit NOT NULL")]
		public bool Startable
		{
			get
			{
				return this._Startable;
			}
			set
			{
				if ((this._Startable != value))
				{
					this._Startable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="Int NOT NULL")]
		public int Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					this._SystemModuleId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemAssemblyName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SystemAssemblyName
		{
			get
			{
				return this._SystemAssemblyName;
			}
			set
			{
				if ((this._SystemAssemblyName != value))
				{
					this._SystemAssemblyName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.vwLiveFlow")]
	public partial class Cloudcoremodel_VwLiveFlow
	{
		
		private int _FlowModelId;
		
		private System.Guid _FlowGuid;
		
		private int _FromActivityId;
		
		private int _FromActivityModelId;
		
		private string _Outcome;
		
		private int _ToActivityId;
		
		private int _ToActivityModelId;
		
		private string _Storyline;
		
		private bool _NegativeFlow;
		
		private bool _OptimalFlow;
		
		public Cloudcoremodel_VwLiveFlow()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowModelId", DbType="Int NOT NULL")]
		public int FlowModelId
		{
			get
			{
				return this._FlowModelId;
			}
			set
			{
				if ((this._FlowModelId != value))
				{
					this._FlowModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid FlowGuid
		{
			get
			{
				return this._FlowGuid;
			}
			set
			{
				if ((this._FlowGuid != value))
				{
					this._FlowGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityId", DbType="Int NOT NULL")]
		public int FromActivityId
		{
			get
			{
				return this._FromActivityId;
			}
			set
			{
				if ((this._FromActivityId != value))
				{
					this._FromActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityModelId", DbType="Int NOT NULL")]
		public int FromActivityModelId
		{
			get
			{
				return this._FromActivityModelId;
			}
			set
			{
				if ((this._FromActivityModelId != value))
				{
					this._FromActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Outcome", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Outcome
		{
			get
			{
				return this._Outcome;
			}
			set
			{
				if ((this._Outcome != value))
				{
					this._Outcome = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityId", DbType="Int NOT NULL")]
		public int ToActivityId
		{
			get
			{
				return this._ToActivityId;
			}
			set
			{
				if ((this._ToActivityId != value))
				{
					this._ToActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityModelId", DbType="Int NOT NULL")]
		public int ToActivityModelId
		{
			get
			{
				return this._ToActivityModelId;
			}
			set
			{
				if ((this._ToActivityModelId != value))
				{
					this._ToActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Storyline", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Storyline
		{
			get
			{
				return this._Storyline;
			}
			set
			{
				if ((this._Storyline != value))
				{
					this._Storyline = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NegativeFlow", DbType="Bit NOT NULL")]
		public bool NegativeFlow
		{
			get
			{
				return this._NegativeFlow;
			}
			set
			{
				if ((this._NegativeFlow != value))
				{
					this._NegativeFlow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OptimalFlow", DbType="Bit NOT NULL")]
		public bool OptimalFlow
		{
			get
			{
				return this._OptimalFlow;
			}
			set
			{
				if ((this._OptimalFlow != value))
				{
					this._OptimalFlow = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.vwLiveFlowDetails")]
	public partial class Cloudcoremodel_VwLiveFlowDetails
	{
		
		private int _FlowModelId;
		
		private System.Guid _FlowGuid;
		
		private int _FromActivityId;
		
		private int _FromActivityModelId;
		
		private string _Outcome;
		
		private int _ToActivityId;
		
		private int _ToActivityModelId;
		
		private string _Storyline;
		
		private bool _NegativeFlow;
		
		private bool _OptimalFlow;
		
		private string _FromActivityName;
		
		private string _FromActivityType;
		
		private string _ToActivityName;
		
		private string _ToActivityType;
		
		private int _SubProcessId;
		
		private int _ProcessRevisionId;
		
		public Cloudcoremodel_VwLiveFlowDetails()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowModelId", DbType="Int NOT NULL")]
		public int FlowModelId
		{
			get
			{
				return this._FlowModelId;
			}
			set
			{
				if ((this._FlowModelId != value))
				{
					this._FlowModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FlowGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid FlowGuid
		{
			get
			{
				return this._FlowGuid;
			}
			set
			{
				if ((this._FlowGuid != value))
				{
					this._FlowGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityId", DbType="Int NOT NULL")]
		public int FromActivityId
		{
			get
			{
				return this._FromActivityId;
			}
			set
			{
				if ((this._FromActivityId != value))
				{
					this._FromActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityModelId", DbType="Int NOT NULL")]
		public int FromActivityModelId
		{
			get
			{
				return this._FromActivityModelId;
			}
			set
			{
				if ((this._FromActivityModelId != value))
				{
					this._FromActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Outcome", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Outcome
		{
			get
			{
				return this._Outcome;
			}
			set
			{
				if ((this._Outcome != value))
				{
					this._Outcome = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityId", DbType="Int NOT NULL")]
		public int ToActivityId
		{
			get
			{
				return this._ToActivityId;
			}
			set
			{
				if ((this._ToActivityId != value))
				{
					this._ToActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityModelId", DbType="Int NOT NULL")]
		public int ToActivityModelId
		{
			get
			{
				return this._ToActivityModelId;
			}
			set
			{
				if ((this._ToActivityModelId != value))
				{
					this._ToActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Storyline", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Storyline
		{
			get
			{
				return this._Storyline;
			}
			set
			{
				if ((this._Storyline != value))
				{
					this._Storyline = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NegativeFlow", DbType="Bit NOT NULL")]
		public bool NegativeFlow
		{
			get
			{
				return this._NegativeFlow;
			}
			set
			{
				if ((this._NegativeFlow != value))
				{
					this._NegativeFlow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OptimalFlow", DbType="Bit NOT NULL")]
		public bool OptimalFlow
		{
			get
			{
				return this._OptimalFlow;
			}
			set
			{
				if ((this._OptimalFlow != value))
				{
					this._OptimalFlow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string FromActivityName
		{
			get
			{
				return this._FromActivityName;
			}
			set
			{
				if ((this._FromActivityName != value))
				{
					this._FromActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromActivityType", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string FromActivityType
		{
			get
			{
				return this._FromActivityType;
			}
			set
			{
				if ((this._FromActivityType != value))
				{
					this._FromActivityType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ToActivityName
		{
			get
			{
				return this._ToActivityName;
			}
			set
			{
				if ((this._ToActivityName != value))
				{
					this._ToActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToActivityType", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ToActivityType
		{
			get
			{
				return this._ToActivityType;
			}
			set
			{
				if ((this._ToActivityType != value))
				{
					this._ToActivityType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.vwLiveProcess")]
	public partial class Cloudcoremodel_VwLiveProcess
	{
		
		private int _ActivityId;
		
		private int _ActivityModelId;
		
		private byte _ActivityTypeId;
		
		private string _ActivityName;
		
		private bool _Startable;
		
		private int _Priority;
		
		private bool _DocWait;
		
		private System.Guid _ActivityGuid;
		
		private int _ProcessModelId;
		
		private string _ProcessName;
		
		private int _ManagerId;
		
		private int _ProcessRevision;
		
		private int _ProcessRevisionId;
		
		private System.Guid _ProcessGuid;
		
		private int _SubProcessId;
		
		private string _SubProcessName;
		
		private System.Guid _SubProcessGuid;
		
		private string _SystemAssemblyName;
		
		private string _ActivityTypeName;
		
		public Cloudcoremodel_VwLiveProcess()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Startable", DbType="Bit NOT NULL")]
		public bool Startable
		{
			get
			{
				return this._Startable;
			}
			set
			{
				if ((this._Startable != value))
				{
					this._Startable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="Int NOT NULL")]
		public int Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					this._ManagerId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevision", DbType="Int NOT NULL")]
		public int ProcessRevision
		{
			get
			{
				return this._ProcessRevision;
			}
			set
			{
				if ((this._ProcessRevision != value))
				{
					this._ProcessRevision = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this._ProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this._SubProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemAssemblyName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SystemAssemblyName
		{
			get
			{
				return this._SystemAssemblyName;
			}
			set
			{
				if ((this._SystemAssemblyName != value))
				{
					this._SystemAssemblyName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this._ActivityTypeName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwNotificationHistory")]
	public partial class Cloudcore_VwNotificationHistory
	{
		
		private int _NotificationId;
		
		private System.DateTime _Created;
		
		private int _Creator;
		
		private string _NFullname;
		
		private string _Subject;
		
		private string _Message;
		
		private System.Nullable<int> _TotalUnread;
		
		public Cloudcore_VwNotificationHistory()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificationId", DbType="Int NOT NULL")]
		public int NotificationId
		{
			get
			{
				return this._NotificationId;
			}
			set
			{
				if ((this._NotificationId != value))
				{
					this._NotificationId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Creator", DbType="Int NOT NULL")]
		public int Creator
		{
			get
			{
				return this._Creator;
			}
			set
			{
				if ((this._Creator != value))
				{
					this._Creator = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NFullname", DbType="VarChar(71) NOT NULL", CanBeNull=false)]
		public string NFullname
		{
			get
			{
				return this._NFullname;
			}
			set
			{
				if ((this._NFullname != value))
				{
					this._NFullname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this._Subject = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalUnread", DbType="Int")]
		public System.Nullable<int> TotalUnread
		{
			get
			{
				return this._TotalUnread;
			}
			set
			{
				if ((this._TotalUnread != value))
				{
					this._TotalUnread = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwOpenTasks")]
	public partial class Cloudcore_VwOpenTasks
	{
		
		private long _InstanceId;
		
		private int _UserId;
		
		public Cloudcore_VwOpenTasks()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwProcessDailyStats")]
	public partial class Cloudcore_VwProcessDailyStats
	{
		
		private System.Nullable<int> _Snoo;
		
		public Cloudcore_VwProcessDailyStats()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="snoo", Storage="_Snoo", DbType="Int")]
		public System.Nullable<int> Snoo
		{
			get
			{
				return this._Snoo;
			}
			set
			{
				if ((this._Snoo != value))
				{
					this._Snoo = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcoremodel.vwProcessModel")]
	public partial class Cloudcoremodel_VwProcessModel
	{
		
		private int _ProcessModelId;
		
		private System.Guid _ProcessGuid;
		
		private string _ProcessName;
		
		private int _ProcessRevisionId;
		
		private int _ManagerId;
		
		private int _ProcessRevision;
		
		private int _UserId;
		
		private int _SubProcessId;
		
		private System.Guid _SubProcessGuid;
		
		private string _SubProcessName;
		
		private int _ActivityModelId;
		
		private System.Guid _ActivityGuid;
		
		private string _ActivityName;
		
		private string _CheckSum;
		
		private System.DateTime _Changed;
		
		public Cloudcoremodel_VwProcessModel()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this._ProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerId", DbType="Int NOT NULL")]
		public int ManagerId
		{
			get
			{
				return this._ManagerId;
			}
			set
			{
				if ((this._ManagerId != value))
				{
					this._ManagerId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevision", DbType="Int NOT NULL")]
		public int ProcessRevision
		{
			get
			{
				return this._ProcessRevision;
			}
			set
			{
				if ((this._ProcessRevision != value))
				{
					this._ProcessRevision = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this._SubProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckSum", DbType="VarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string CheckSum
		{
			get
			{
				return this._CheckSum;
			}
			set
			{
				if ((this._CheckSum != value))
				{
					this._CheckSum = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Changed", DbType="DateTime NOT NULL")]
		public System.DateTime Changed
		{
			get
			{
				return this._Changed;
			}
			set
			{
				if ((this._Changed != value))
				{
					this._Changed = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwProcessStats")]
	public partial class Cloudcore_VwProcessStats
	{
		
		private int _ProcessRevisionId;
		
		private string _Status;
		
		private System.Nullable<int> _Cnt;
		
		public Cloudcore_VwProcessStats()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="cnt", Storage="_Cnt", DbType="Int")]
		public System.Nullable<int> Cnt
		{
			get
			{
				return this._Cnt;
			}
			set
			{
				if ((this._Cnt != value))
				{
					this._Cnt = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwTasklist")]
	public partial class Cloudcore_VwTasklist
	{
		
		private int _ActivityId;
		
		private byte _ActivityTypeId;
		
		private string _ActivityTypeName;
		
		private System.DateTime _Assigned;
		
		private string _SubProcessName;
		
		private int _ProcessRevisionId;
		
		private System.Nullable<bool> _Delayed;
		
		private int _OpenedBy;
		
		private int _AllocatedTo;
		
		private int _UserId;
		
		private byte _StatusTypeId;
		
		private long _InstanceId;
		
		private int _SubProcessId;
		
		private int _ProcessModelId;
		
		private string _ProcessName;
		
		private System.DateTime _Activate;
		
		private byte _Priority;
		
		private string _ActivityName;
		
		private long _KeyValue;
		
		private System.DateTime _Created;
		
		private bool _DocWait;
		
		public Cloudcore_VwTasklist()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this._ActivityTypeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assigned", DbType="DateTime NOT NULL")]
		public System.DateTime Assigned
		{
			get
			{
				return this._Assigned;
			}
			set
			{
				if ((this._Assigned != value))
				{
					this._Assigned = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Delayed", DbType="Bit")]
		public System.Nullable<bool> Delayed
		{
			get
			{
				return this._Delayed;
			}
			set
			{
				if ((this._Delayed != value))
				{
					this._Delayed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenedBy", DbType="Int NOT NULL")]
		public int OpenedBy
		{
			get
			{
				return this._OpenedBy;
			}
			set
			{
				if ((this._OpenedBy != value))
				{
					this._OpenedBy = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AllocatedTo", DbType="Int NOT NULL")]
		public int AllocatedTo
		{
			get
			{
				return this._AllocatedTo;
			}
			set
			{
				if ((this._AllocatedTo != value))
				{
					this._AllocatedTo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					this._StatusTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this._Activate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this._KeyValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwTaskListFilter")]
	public partial class Cloudcore_VwTaskListFilter
	{
		
		private int _UserId;
		
		private int _ProcessRevisionId;
		
		private int _ActivityId;
		
		private string _ActivityName;
		
		private int _SubProcessId;
		
		private string _SubProcessName;
		
		public Cloudcore_VwTaskListFilter()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwTasklistHistory")]
	public partial class Cloudcore_VwTasklistHistory
	{
		
		private long _InstanceId;
		
		private System.DateTime _Completed;
		
		private string _Storyline;
		
		public Cloudcore_VwTasklistHistory()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Completed", DbType="DateTime NOT NULL")]
		public System.DateTime Completed
		{
			get
			{
				return this._Completed;
			}
			set
			{
				if ((this._Completed != value))
				{
					this._Completed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Storyline", DbType="VarChar(272) NOT NULL", CanBeNull=false)]
		public string Storyline
		{
			get
			{
				return this._Storyline;
			}
			set
			{
				if ((this._Storyline != value))
				{
					this._Storyline = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserAccess")]
	public partial class Cloudcore_VwUserAccess
	{
		
		private int _UserId;
		
		private string _Email;
		
		private string _Login;
		
		private string _Account;
		
		private int _Active;
		
		private bool _IntAccess;
		
		private bool _ExtAccess;
		
		private string _Firstnames;
		
		private string _Preferredname;
		
		private string _Surname;
		
		private System.DateTime _LastLoginDateTime;
		
		public Cloudcore_VwUserAccess()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL IDENTITY")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="VarChar(320) NOT NULL", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this._Login = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Account
		{
			get
			{
				return this._Account;
			}
			set
			{
				if ((this._Account != value))
				{
					this._Account = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Int NOT NULL")]
		public int Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this._Active = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntAccess", DbType="Bit NOT NULL")]
		public bool IntAccess
		{
			get
			{
				return this._IntAccess;
			}
			set
			{
				if ((this._IntAccess != value))
				{
					this._IntAccess = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExtAccess", DbType="Bit NOT NULL")]
		public bool ExtAccess
		{
			get
			{
				return this._ExtAccess;
			}
			set
			{
				if ((this._ExtAccess != value))
				{
					this._ExtAccess = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Firstnames", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Firstnames
		{
			get
			{
				return this._Firstnames;
			}
			set
			{
				if ((this._Firstnames != value))
				{
					this._Firstnames = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Preferredname", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string Preferredname
		{
			get
			{
				return this._Preferredname;
			}
			set
			{
				if ((this._Preferredname != value))
				{
					this._Preferredname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this._Surname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLoginDateTime", DbType="DateTime NOT NULL")]
		public System.DateTime LastLoginDateTime
		{
			get
			{
				return this._LastLoginDateTime;
			}
			set
			{
				if ((this._LastLoginDateTime != value))
				{
					this._LastLoginDateTime = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserDashboard")]
	public partial class Cloudcore_VwUserDashboard
	{
		
		private string _AssemblyName;
		
		private int _DashboardUserAllocationId;
		
		private int _UserId;
		
		private int _DashboardId;
		
		private int _TilePosition;
		
		private int _SystemModuleId;
		
		private string _Description;
		
		private string _Title;
		
		private string _ClassName;
		
		public Cloudcore_VwUserDashboard()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssemblyName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AssemblyName
		{
			get
			{
				return this._AssemblyName;
			}
			set
			{
				if ((this._AssemblyName != value))
				{
					this._AssemblyName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardUserAllocationId", DbType="Int NOT NULL")]
		public int DashboardUserAllocationId
		{
			get
			{
				return this._DashboardUserAllocationId;
			}
			set
			{
				if ((this._DashboardUserAllocationId != value))
				{
					this._DashboardUserAllocationId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DashboardId", DbType="Int NOT NULL")]
		public int DashboardId
		{
			get
			{
				return this._DashboardId;
			}
			set
			{
				if ((this._DashboardId != value))
				{
					this._DashboardId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TilePosition", DbType="Int NOT NULL")]
		public int TilePosition
		{
			get
			{
				return this._TilePosition;
			}
			set
			{
				if ((this._TilePosition != value))
				{
					this._TilePosition = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					this._SystemModuleId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string ClassName
		{
			get
			{
				return this._ClassName;
			}
			set
			{
				if ((this._ClassName != value))
				{
					this._ClassName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserModule")]
	public partial class Cloudcore_VwUserModule
	{
		
		private int _UserId;
		
		private int _SystemModuleId;
		
		private string _AssemblyName;
		
		public Cloudcore_VwUserModule()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemModuleId", DbType="Int NOT NULL")]
		public int SystemModuleId
		{
			get
			{
				return this._SystemModuleId;
			}
			set
			{
				if ((this._SystemModuleId != value))
				{
					this._SystemModuleId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssemblyName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string AssemblyName
		{
			get
			{
				return this._AssemblyName;
			}
			set
			{
				if ((this._AssemblyName != value))
				{
					this._AssemblyName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserMonthlyTaskAgeAverage")]
	public partial class Cloudcore_VwUserMonthlyTaskAgeAverage
	{
		
		private System.Nullable<int> _AverageAge;
		
		private int _UserId;
		
		private string _ActivityName;
		
		private System.Nullable<int> _AMonth;
		
		private System.Nullable<int> _AYear;
		
		private System.Nullable<long> _Ranking2;
		
		public Cloudcore_VwUserMonthlyTaskAgeAverage()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AverageAge", DbType="Int")]
		public System.Nullable<int> AverageAge
		{
			get
			{
				return this._AverageAge;
			}
			set
			{
				if ((this._AverageAge != value))
				{
					this._AverageAge = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AMonth", DbType="Int")]
		public System.Nullable<int> AMonth
		{
			get
			{
				return this._AMonth;
			}
			set
			{
				if ((this._AMonth != value))
				{
					this._AMonth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AYear", DbType="Int")]
		public System.Nullable<int> AYear
		{
			get
			{
				return this._AYear;
			}
			set
			{
				if ((this._AYear != value))
				{
					this._AYear = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ranking2", DbType="BigInt")]
		public System.Nullable<long> Ranking2
		{
			get
			{
				return this._Ranking2;
			}
			set
			{
				if ((this._Ranking2 != value))
				{
					this._Ranking2 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserMonthlyTaskCompletedCount")]
	public partial class Cloudcore_VwUserMonthlyTaskCompletedCount
	{
		
		private int _UserId;
		
		private System.Nullable<int> _AMonth;
		
		private string _ActivityName;
		
		private System.Nullable<int> _TaskGUIDCount;
		
		private System.Nullable<long> _Ranking2;
		
		public Cloudcore_VwUserMonthlyTaskCompletedCount()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AMonth", DbType="Int")]
		public System.Nullable<int> AMonth
		{
			get
			{
				return this._AMonth;
			}
			set
			{
				if ((this._AMonth != value))
				{
					this._AMonth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskGUIDCount", DbType="Int")]
		public System.Nullable<int> TaskGUIDCount
		{
			get
			{
				return this._TaskGUIDCount;
			}
			set
			{
				if ((this._TaskGUIDCount != value))
				{
					this._TaskGUIDCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ranking2", DbType="BigInt")]
		public System.Nullable<long> Ranking2
		{
			get
			{
				return this._Ranking2;
			}
			set
			{
				if ((this._Ranking2 != value))
				{
					this._Ranking2 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserNotification")]
	public partial class Cloudcore_VwUserNotification
	{
		
		private int _UserId;
		
		private int _CreatorId;
		
		private string _CreatorName;
		
		private int _NotificationId;
		
		private bool _HasRead;
		
		private string _Subject;
		
		private string _Message;
		
		private System.DateTime _Created;
		
		public Cloudcore_VwUserNotification()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatorId", DbType="Int NOT NULL")]
		public int CreatorId
		{
			get
			{
				return this._CreatorId;
			}
			set
			{
				if ((this._CreatorId != value))
				{
					this._CreatorId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatorName", DbType="VarChar(131) NOT NULL", CanBeNull=false)]
		public string CreatorName
		{
			get
			{
				return this._CreatorName;
			}
			set
			{
				if ((this._CreatorName != value))
				{
					this._CreatorName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificationId", DbType="Int NOT NULL")]
		public int NotificationId
		{
			get
			{
				return this._NotificationId;
			}
			set
			{
				if ((this._NotificationId != value))
				{
					this._NotificationId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasRead", DbType="Bit NOT NULL")]
		public bool HasRead
		{
			get
			{
				return this._HasRead;
			}
			set
			{
				if ((this._HasRead != value))
				{
					this._HasRead = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this._Subject = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwUserWeeklyTaskCompletedCount")]
	public partial class Cloudcore_VwUserWeeklyTaskCompletedCount
	{
		
		private int _UserId;
		
		private System.Nullable<System.DateTime> _ADate;
		
		private string _ActivityName;
		
		private System.Nullable<int> _TaskGUIDCount;
		
		private System.Nullable<long> _Ranking2;
		
		public Cloudcore_VwUserWeeklyTaskCompletedCount()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADate", DbType="Date")]
		public System.Nullable<System.DateTime> ADate
		{
			get
			{
				return this._ADate;
			}
			set
			{
				if ((this._ADate != value))
				{
					this._ADate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskGUIDCount", DbType="Int")]
		public System.Nullable<int> TaskGUIDCount
		{
			get
			{
				return this._TaskGUIDCount;
			}
			set
			{
				if ((this._TaskGUIDCount != value))
				{
					this._TaskGUIDCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ranking2", DbType="BigInt")]
		public System.Nullable<long> Ranking2
		{
			get
			{
				return this._Ranking2;
			}
			set
			{
				if ((this._Ranking2 != value))
				{
					this._Ranking2 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwWorklist")]
	public partial class Cloudcore_VwWorklist
	{
		
		private long _InstanceId;
		
		private System.Nullable<long> _PInstanceId;
		
		private byte _StatusTypeId;
		
		private bool _DocWait;
		
		private int _UserId;
		
		private byte _Priority;
		
		private long _KeyValue;
		
		private System.DateTime _Activate;
		
		private System.DateTime _Opened;
		
		private System.DateTime _Created;
		
		private int _ActivityId;
		
		private int _ActivityModelId;
		
		private string _ActivityName;
		
		private bool _Startable;
		
		private byte _ActivityTypeId;
		
		private string _ActivityTypeName;
		
		private string _ProcessName;
		
		private int _ProcessModelId;
		
		private System.DateTime _Assigned;
		
		private System.Guid _ProcessGuid;
		
		private System.Nullable<bool> _Delayed;
		
		private System.Guid _ActivityGuid;
		
		private int _SubProcessId;
		
		private string _SubProcessName;
		
		public Cloudcore_VwWorklist()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PInstanceId", DbType="BigInt")]
		public System.Nullable<long> PInstanceId
		{
			get
			{
				return this._PInstanceId;
			}
			set
			{
				if ((this._PInstanceId != value))
				{
					this._PInstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					this._StatusTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this._KeyValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this._Activate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opened", DbType="DateTime NOT NULL")]
		public System.DateTime Opened
		{
			get
			{
				return this._Opened;
			}
			set
			{
				if ((this._Opened != value))
				{
					this._Opened = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Startable", DbType="Bit NOT NULL")]
		public bool Startable
		{
			get
			{
				return this._Startable;
			}
			set
			{
				if ((this._Startable != value))
				{
					this._Startable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this._ActivityTypeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assigned", DbType="DateTime NOT NULL")]
		public System.DateTime Assigned
		{
			get
			{
				return this._Assigned;
			}
			set
			{
				if ((this._Assigned != value))
				{
					this._Assigned = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this._ProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Delayed", DbType="Bit")]
		public System.Nullable<bool> Delayed
		{
			get
			{
				return this._Delayed;
			}
			set
			{
				if ((this._Delayed != value))
				{
					this._Delayed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.vwWorklistEx")]
	public partial class Cloudcore_VwWorklistEx
	{
		
		private long _InstanceId;
		
		private System.Nullable<long> _PInstanceId;
		
		private byte _StatusTypeId;
		
		private string _StatusTypeName;
		
		private bool _DocWait;
		
		private int _UserId;
		
		private int _OpenedBy;
		
		private byte _Priority;
		
		private long _KeyValue;
		
		private System.DateTime _Activate;
		
		private System.DateTime _Assigned;
		
		private System.DateTime _Opened;
		
		private System.DateTime _Created;
		
		private int _ActivityId;
		
		private int _ActivityModelId;
		
		private string _ActivityName;
		
		private bool _Startable;
		
		private byte _ActivityTypeId;
		
		private int _ProcessRevisionId;
		
		private string _ActivityTypeName;
		
		private string _ProcessName;
		
		private int _ProcessModelId;
		
		private int _SubProcessId;
		
		private string _UserName;
		
		private string _SubProcessName;
		
		private System.Guid _ActivityGuid;
		
		private System.Guid _ProcessGuid;
		
		private System.Guid _SubProcessGuid;
		
		public Cloudcore_VwWorklistEx()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL")]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this._InstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PInstanceId", DbType="BigInt")]
		public System.Nullable<long> PInstanceId
		{
			get
			{
				return this._PInstanceId;
			}
			set
			{
				if ((this._PInstanceId != value))
				{
					this._PInstanceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					this._StatusTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string StatusTypeName
		{
			get
			{
				return this._StatusTypeName;
			}
			set
			{
				if ((this._StatusTypeName != value))
				{
					this._StatusTypeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this._DocWait = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenedBy", DbType="Int NOT NULL")]
		public int OpenedBy
		{
			get
			{
				return this._OpenedBy;
			}
			set
			{
				if ((this._OpenedBy != value))
				{
					this._OpenedBy = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this._Priority = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this._KeyValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this._Activate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assigned", DbType="DateTime NOT NULL")]
		public System.DateTime Assigned
		{
			get
			{
				return this._Assigned;
			}
			set
			{
				if ((this._Assigned != value))
				{
					this._Assigned = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opened", DbType="DateTime NOT NULL")]
		public System.DateTime Opened
		{
			get
			{
				return this._Opened;
			}
			set
			{
				if ((this._Opened != value))
				{
					this._Opened = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this._Created = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this._ActivityId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int NOT NULL")]
		public int ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Startable", DbType="Bit NOT NULL")]
		public bool Startable
		{
			get
			{
				return this._Startable;
			}
			set
			{
				if ((this._Startable != value))
				{
					this._Startable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeId", DbType="TinyInt NOT NULL")]
		public byte ActivityTypeId
		{
			get
			{
				return this._ActivityTypeId;
			}
			set
			{
				if ((this._ActivityTypeId != value))
				{
					this._ActivityTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessRevisionId", DbType="Int NOT NULL")]
		public int ProcessRevisionId
		{
			get
			{
				return this._ProcessRevisionId;
			}
			set
			{
				if ((this._ProcessRevisionId != value))
				{
					this._ProcessRevisionId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityTypeName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string ActivityTypeName
		{
			get
			{
				return this._ActivityTypeName;
			}
			set
			{
				if ((this._ActivityTypeName != value))
				{
					this._ActivityTypeName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProcessName
		{
			get
			{
				return this._ProcessName;
			}
			set
			{
				if ((this._ProcessName != value))
				{
					this._ProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int NOT NULL")]
		public int ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessId", DbType="Int NOT NULL")]
		public int SubProcessId
		{
			get
			{
				return this._SubProcessId;
			}
			set
			{
				if ((this._SubProcessId != value))
				{
					this._SubProcessId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(131) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string SubProcessName
		{
			get
			{
				return this._SubProcessName;
			}
			set
			{
				if ((this._SubProcessName != value))
				{
					this._SubProcessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityGuid
		{
			get
			{
				return this._ActivityGuid;
			}
			set
			{
				if ((this._ActivityGuid != value))
				{
					this._ActivityGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProcessGuid
		{
			get
			{
				return this._ProcessGuid;
			}
			set
			{
				if ((this._ProcessGuid != value))
				{
					this._ProcessGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProcessGuid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SubProcessGuid
		{
			get
			{
				return this._SubProcessGuid;
			}
			set
			{
				if ((this._SubProcessGuid != value))
				{
					this._SubProcessGuid = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.Worklist")]
	public partial class Cloudcore_Worklist : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _InstanceId;
		
		private System.Nullable<long> _PInstanceId;
		
		private int _ActivityId;
		
		private byte _StatusTypeId;
		
		private bool _DocWait;
		
		private byte _Priority;
		
		private int _UserId;
		
		private System.DateTime _Assigned;
		
		private int _OpenedBy;
		
		private System.DateTime _Opened;
		
		private System.DateTime _Activate;
		
		private long _KeyValue;
		
		private System.DateTime _Created;
		
		private System.Nullable<bool> _Delayed;
		
		private System.Nullable<System.DateTime> _Age;
		
		private EntitySet<Cloudcore_CampaignItem> _Cloudcore_CampaignItem;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
		private EntityRef<Cloudcoremodel_StatusType> _Cloudcoremodel_StatusType;
		
		private EntityRef<Cloudcore_User> _User;
		
		private EntityRef<Cloudcore_WorklistFailure> _Cloudcore_WorklistFailure;
		
		private EntitySet<Cloudcore_WorklistReference> _Cloudcore_WorklistReference;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnPInstanceIdChanging(System.Nullable<long> value);
    partial void OnPInstanceIdChanged();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    partial void OnStatusTypeIdChanging(byte value);
    partial void OnStatusTypeIdChanged();
    partial void OnDocWaitChanging(bool value);
    partial void OnDocWaitChanged();
    partial void OnPriorityChanging(byte value);
    partial void OnPriorityChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnAssignedChanging(System.DateTime value);
    partial void OnAssignedChanged();
    partial void OnOpenedByChanging(int value);
    partial void OnOpenedByChanged();
    partial void OnOpenedChanging(System.DateTime value);
    partial void OnOpenedChanged();
    partial void OnActivateChanging(System.DateTime value);
    partial void OnActivateChanged();
    partial void OnKeyValueChanging(long value);
    partial void OnKeyValueChanged();
    partial void OnCreatedChanging(System.DateTime value);
    partial void OnCreatedChanged();
    partial void OnDelayedChanging(System.Nullable<bool> value);
    partial void OnDelayedChanged();
    partial void OnAgeChanging(System.Nullable<System.DateTime> value);
    partial void OnAgeChanged();
    #endregion
		
		public Cloudcore_Worklist()
		{
			this._Cloudcore_CampaignItem = new EntitySet<Cloudcore_CampaignItem>(new Action<Cloudcore_CampaignItem>(this.attach_Cloudcore_CampaignItem), new Action<Cloudcore_CampaignItem>(this.detach_Cloudcore_CampaignItem));
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			this._Cloudcoremodel_StatusType = default(EntityRef<Cloudcoremodel_StatusType>);
			this._User = default(EntityRef<Cloudcore_User>);
			this._Cloudcore_WorklistFailure = default(EntityRef<Cloudcore_WorklistFailure>);
			this._Cloudcore_WorklistReference = new EntitySet<Cloudcore_WorklistReference>(new Action<Cloudcore_WorklistReference>(this.attach_Cloudcore_WorklistReference), new Action<Cloudcore_WorklistReference>(this.detach_Cloudcore_WorklistReference));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PInstanceId", DbType="BigInt")]
		public System.Nullable<long> PInstanceId
		{
			get
			{
				return this._PInstanceId;
			}
			set
			{
				if ((this._PInstanceId != value))
				{
					this.OnPInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._PInstanceId = value;
					this.SendPropertyChanged("PInstanceId");
					this.OnPInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					if (this._Cloudcore_Activity.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusTypeId", DbType="TinyInt NOT NULL")]
		public byte StatusTypeId
		{
			get
			{
				return this._StatusTypeId;
			}
			set
			{
				if ((this._StatusTypeId != value))
				{
					if (this._Cloudcoremodel_StatusType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStatusTypeIdChanging(value);
					this.SendPropertyChanging();
					this._StatusTypeId = value;
					this.SendPropertyChanged("StatusTypeId");
					this.OnStatusTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocWait", DbType="Bit NOT NULL")]
		public bool DocWait
		{
			get
			{
				return this._DocWait;
			}
			set
			{
				if ((this._DocWait != value))
				{
					this.OnDocWaitChanging(value);
					this.SendPropertyChanging();
					this._DocWait = value;
					this.SendPropertyChanged("DocWait");
					this.OnDocWaitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Priority", DbType="TinyInt NOT NULL")]
		public byte Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				if ((this._Priority != value))
				{
					this.OnPriorityChanging(value);
					this.SendPropertyChanging();
					this._Priority = value;
					this.SendPropertyChanged("Priority");
					this.OnPriorityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assigned", DbType="DateTime NOT NULL")]
		public System.DateTime Assigned
		{
			get
			{
				return this._Assigned;
			}
			set
			{
				if ((this._Assigned != value))
				{
					this.OnAssignedChanging(value);
					this.SendPropertyChanging();
					this._Assigned = value;
					this.SendPropertyChanged("Assigned");
					this.OnAssignedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenedBy", DbType="Int NOT NULL")]
		public int OpenedBy
		{
			get
			{
				return this._OpenedBy;
			}
			set
			{
				if ((this._OpenedBy != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOpenedByChanging(value);
					this.SendPropertyChanging();
					this._OpenedBy = value;
					this.SendPropertyChanged("OpenedBy");
					this.OnOpenedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opened", DbType="DateTime NOT NULL")]
		public System.DateTime Opened
		{
			get
			{
				return this._Opened;
			}
			set
			{
				if ((this._Opened != value))
				{
					this.OnOpenedChanging(value);
					this.SendPropertyChanging();
					this._Opened = value;
					this.SendPropertyChanged("Opened");
					this.OnOpenedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Activate", DbType="DateTime NOT NULL")]
		public System.DateTime Activate
		{
			get
			{
				return this._Activate;
			}
			set
			{
				if ((this._Activate != value))
				{
					this.OnActivateChanging(value);
					this.SendPropertyChanging();
					this._Activate = value;
					this.SendPropertyChanged("Activate");
					this.OnActivateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this.OnKeyValueChanging(value);
					this.SendPropertyChanging();
					this._KeyValue = value;
					this.SendPropertyChanged("KeyValue");
					this.OnKeyValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime NOT NULL")]
		public System.DateTime Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Delayed", AutoSync=AutoSync.Always, DbType="Bit", IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(CONVERT([bit],case when [Activate]<=getdate() then (0) else (1) end,(0)))")]
		public System.Nullable<bool> Delayed
		{
			get
			{
				return this._Delayed;
			}
			set
			{
				if ((this._Delayed != value))
				{
					this.OnDelayedChanging(value);
					this.SendPropertyChanging();
					this._Delayed = value;
					this.SendPropertyChanged("Delayed");
					this.OnDelayedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", AutoSync=AutoSync.Always, DbType="DateTime", IsDbGenerated=true, UpdateCheck=UpdateCheck.Never, Expression="(getdate()-[Assigned])")]
		public System.Nullable<System.DateTime> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_CampaignItem_Worklist", Storage="_Cloudcore_CampaignItem", ThisKey="InstanceId", OtherKey="InstanceId", DeleteRule="NO ACTION")]
		public EntitySet<Cloudcore_CampaignItem> Cloudcore_CampaignItem
		{
			get
			{
				return this._Cloudcore_CampaignItem;
			}
			set
			{
				this._Cloudcore_CampaignItem.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_Activity", Storage="_Cloudcore_Activity", ThisKey="ActivityId", OtherKey="ActivityId", IsForeignKey=true)]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcore_Worklist.Remove(this);
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Worklist.Add(this);
						this._ActivityId = value.ActivityId;
					}
					else
					{
						this._ActivityId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_OpenedBy", Storage="_Cloudcore_User", ThisKey="OpenedBy", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_Worklist.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Worklist.Add(this);
						this._OpenedBy = value.UserId;
					}
					else
					{
						this._OpenedBy = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_StatusType", Storage="_Cloudcoremodel_StatusType", ThisKey="StatusTypeId", OtherKey="StatusTypeId", IsForeignKey=true)]
		public Cloudcoremodel_StatusType Cloudcoremodel_StatusType
		{
			get
			{
				return this._Cloudcoremodel_StatusType.Entity;
			}
			set
			{
				Cloudcoremodel_StatusType previousValue = this._Cloudcoremodel_StatusType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcoremodel_StatusType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcoremodel_StatusType.Entity = null;
						previousValue.Cloudcore_Worklist.Remove(this);
					}
					this._Cloudcoremodel_StatusType.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Worklist.Add(this);
						this._StatusTypeId = value.StatusTypeId;
					}
					else
					{
						this._StatusTypeId = default(byte);
					}
					this.SendPropertyChanged("Cloudcoremodel_StatusType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_Worklist_User_UserId", Storage="_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.User.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.User.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistFailure_Worklist", Storage="_Cloudcore_WorklistFailure", ThisKey="InstanceId", OtherKey="InstanceId", IsUnique=true, IsForeignKey=false, DeleteRule="NO ACTION")]
		public Cloudcore_WorklistFailure Cloudcore_WorklistFailure
		{
			get
			{
				return this._Cloudcore_WorklistFailure.Entity;
			}
			set
			{
				Cloudcore_WorklistFailure previousValue = this._Cloudcore_WorklistFailure.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_WorklistFailure.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_WorklistFailure.Entity = null;
						previousValue.Cloudcore_Worklist = null;
					}
					this._Cloudcore_WorklistFailure.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_Worklist = this;
					}
					this.SendPropertyChanged("Cloudcore_WorklistFailure");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistReference_Worklist", Storage="_Cloudcore_WorklistReference", ThisKey="InstanceId", OtherKey="InstanceId", DeleteRule="CASCADE")]
		public EntitySet<Cloudcore_WorklistReference> Cloudcore_WorklistReference
		{
			get
			{
				return this._Cloudcore_WorklistReference;
			}
			set
			{
				this._Cloudcore_WorklistReference.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Worklist = this;
		}
		
		private void detach_Cloudcore_CampaignItem(Cloudcore_CampaignItem entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Worklist = null;
		}
		
		private void attach_Cloudcore_WorklistReference(Cloudcore_WorklistReference entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Worklist = this;
		}
		
		private void detach_Cloudcore_WorklistReference(Cloudcore_WorklistReference entity)
		{
			this.SendPropertyChanging();
			entity.Cloudcore_Worklist = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.WorklistFailure")]
	public partial class Cloudcore_WorklistFailure : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _InstanceId;
		
		private int _ActivityId;
		
		private long _KeyValue;
		
		private System.DateTime _FailedAt;
		
		private int _UserId;
		
		private string _Reason;
		
		private EntityRef<Cloudcore_Activity> _Cloudcore_Activity;
		
		private EntityRef<Cloudcore_User> _Cloudcore_User;
		
		private EntityRef<Cloudcore_Worklist> _Cloudcore_Worklist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnActivityIdChanging(int value);
    partial void OnActivityIdChanged();
    partial void OnKeyValueChanging(long value);
    partial void OnKeyValueChanged();
    partial void OnFailedAtChanging(System.DateTime value);
    partial void OnFailedAtChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    #endregion
		
		public Cloudcore_WorklistFailure()
		{
			this._Cloudcore_Activity = default(EntityRef<Cloudcore_Activity>);
			this._Cloudcore_User = default(EntityRef<Cloudcore_User>);
			this._Cloudcore_Worklist = default(EntityRef<Cloudcore_Worklist>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					if (this._Cloudcore_Worklist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="Int NOT NULL")]
		public int ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					if (this._Cloudcore_Activity.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KeyValue", DbType="BigInt NOT NULL")]
		public long KeyValue
		{
			get
			{
				return this._KeyValue;
			}
			set
			{
				if ((this._KeyValue != value))
				{
					this.OnKeyValueChanging(value);
					this.SendPropertyChanging();
					this._KeyValue = value;
					this.SendPropertyChanged("KeyValue");
					this.OnKeyValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FailedAt", DbType="DateTime NOT NULL")]
		public System.DateTime FailedAt
		{
			get
			{
				return this._FailedAt;
			}
			set
			{
				if ((this._FailedAt != value))
				{
					this.OnFailedAtChanging(value);
					this.SendPropertyChanging();
					this._FailedAt = value;
					this.SendPropertyChanged("FailedAt");
					this.OnFailedAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Cloudcore_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="VarChar(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this.OnReasonChanging(value);
					this.SendPropertyChanging();
					this._Reason = value;
					this.SendPropertyChanged("Reason");
					this.OnReasonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailed_Activity", Storage="_Cloudcore_Activity", ThisKey="ActivityId", OtherKey="ActivityId", IsForeignKey=true)]
		public Cloudcore_Activity Cloudcore_Activity
		{
			get
			{
				return this._Cloudcore_Activity.Entity;
			}
			set
			{
				Cloudcore_Activity previousValue = this._Cloudcore_Activity.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Activity.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Activity.Entity = null;
						previousValue.Cloudcore_WorklistFailure.Remove(this);
					}
					this._Cloudcore_Activity.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_WorklistFailure.Add(this);
						this._ActivityId = value.ActivityId;
					}
					else
					{
						this._ActivityId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_Activity");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_ActivityFailed_User", Storage="_Cloudcore_User", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public Cloudcore_User Cloudcore_User
		{
			get
			{
				return this._Cloudcore_User.Entity;
			}
			set
			{
				Cloudcore_User previousValue = this._Cloudcore_User.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_User.Entity = null;
						previousValue.Cloudcore_WorklistFailure.Remove(this);
					}
					this._Cloudcore_User.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_WorklistFailure.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistFailure_Worklist", Storage="_Cloudcore_Worklist", ThisKey="InstanceId", OtherKey="InstanceId", IsForeignKey=true)]
		public Cloudcore_Worklist Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist.Entity;
			}
			set
			{
				Cloudcore_Worklist previousValue = this._Cloudcore_Worklist.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Worklist.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Worklist.Entity = null;
						previousValue.Cloudcore_WorklistFailure = null;
					}
					this._Cloudcore_Worklist.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_WorklistFailure = this;
						this._InstanceId = value.InstanceId;
					}
					else
					{
						this._InstanceId = default(long);
					}
					this.SendPropertyChanged("Cloudcore_Worklist");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cloudcore.WorklistReference")]
	public partial class Cloudcore_WorklistReference : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _InstanceId;
		
		private int _ReferenceTypeId;
		
		private string _Reference;
		
		private EntityRef<Cloudcore_ReferenceType> _Cloudcore_ReferenceType;
		
		private EntityRef<Cloudcore_Worklist> _Cloudcore_Worklist;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInstanceIdChanging(long value);
    partial void OnInstanceIdChanged();
    partial void OnReferenceTypeIdChanging(int value);
    partial void OnReferenceTypeIdChanged();
    partial void OnReferenceChanging(string value);
    partial void OnReferenceChanged();
    #endregion
		
		public Cloudcore_WorklistReference()
		{
			this._Cloudcore_ReferenceType = default(EntityRef<Cloudcore_ReferenceType>);
			this._Cloudcore_Worklist = default(EntityRef<Cloudcore_Worklist>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanceId", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long InstanceId
		{
			get
			{
				return this._InstanceId;
			}
			set
			{
				if ((this._InstanceId != value))
				{
					if (this._Cloudcore_Worklist.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnInstanceIdChanging(value);
					this.SendPropertyChanging();
					this._InstanceId = value;
					this.SendPropertyChanged("InstanceId");
					this.OnInstanceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReferenceTypeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ReferenceTypeId
		{
			get
			{
				return this._ReferenceTypeId;
			}
			set
			{
				if ((this._ReferenceTypeId != value))
				{
					if (this._Cloudcore_ReferenceType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnReferenceTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ReferenceTypeId = value;
					this.SendPropertyChanged("ReferenceTypeId");
					this.OnReferenceTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reference", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Reference
		{
			get
			{
				return this._Reference;
			}
			set
			{
				if ((this._Reference != value))
				{
					this.OnReferenceChanging(value);
					this.SendPropertyChanging();
					this._Reference = value;
					this.SendPropertyChanged("Reference");
					this.OnReferenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistReference_ReferenceType", Storage="_Cloudcore_ReferenceType", ThisKey="ReferenceTypeId", OtherKey="ReferenceTypeId", IsForeignKey=true)]
		public Cloudcore_ReferenceType Cloudcore_ReferenceType
		{
			get
			{
				return this._Cloudcore_ReferenceType.Entity;
			}
			set
			{
				Cloudcore_ReferenceType previousValue = this._Cloudcore_ReferenceType.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_ReferenceType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_ReferenceType.Entity = null;
						previousValue.Cloudcore_WorklistReference.Remove(this);
					}
					this._Cloudcore_ReferenceType.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_WorklistReference.Add(this);
						this._ReferenceTypeId = value.ReferenceTypeId;
					}
					else
					{
						this._ReferenceTypeId = default(int);
					}
					this.SendPropertyChanged("Cloudcore_ReferenceType");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="FK_WorklistReference_Worklist", Storage="_Cloudcore_Worklist", ThisKey="InstanceId", OtherKey="InstanceId", IsForeignKey=true, DeleteOnNull=true)]
		public Cloudcore_Worklist Cloudcore_Worklist
		{
			get
			{
				return this._Cloudcore_Worklist.Entity;
			}
			set
			{
				Cloudcore_Worklist previousValue = this._Cloudcore_Worklist.Entity;
				if (((previousValue != value) 
							|| (this._Cloudcore_Worklist.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cloudcore_Worklist.Entity = null;
						previousValue.Cloudcore_WorklistReference.Remove(this);
					}
					this._Cloudcore_Worklist.Entity = value;
					if ((value != null))
					{
						value.Cloudcore_WorklistReference.Add(this);
						this._InstanceId = value.InstanceId;
					}
					else
					{
						this._InstanceId = default(long);
					}
					this.SendPropertyChanged("Cloudcore_Worklist");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class Cloudcore_MenuSearchResult
	{
		
		private System.Nullable<int> _Id;
		
		private System.Nullable<int> _Pid;
		
		private string _Area;
		
		private string _Controller;
		
		private string _Action;
		
		private string _Title;
		
		private string _Mtype;
		
		public Cloudcore_MenuSearchResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id", Storage="_Id", DbType="Int")]
		public System.Nullable<int> Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="pid", Storage="_Pid", DbType="Int")]
		public System.Nullable<int> Pid
		{
			get
			{
				return this._Pid;
			}
			set
			{
				if ((this._Pid != value))
				{
					this._Pid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="VarChar(100)")]
		public string Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this._Area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Controller", DbType="VarChar(100)")]
		public string Controller
		{
			get
			{
				return this._Controller;
			}
			set
			{
				if ((this._Controller != value))
				{
					this._Controller = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Action", DbType="VarChar(100)")]
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				if ((this._Action != value))
				{
					this._Action = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="title", Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="mtype", Storage="_Mtype", DbType="VarChar(10)")]
		public string Mtype
		{
			get
			{
				return this._Mtype;
			}
			set
			{
				if ((this._Mtype != value))
				{
					this._Mtype = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_MenuSelectResult
	{
		
		private System.Nullable<int> _PID;
		
		private System.Nullable<int> _ID;
		
		private string _Area;
		
		private string _Controller;
		
		private string _Action;
		
		private string _Title;
		
		private string _Type;
		
		private string _DefaultNamespace;
		
		public Cloudcore_MenuSelectResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PID", DbType="Int")]
		public System.Nullable<int> PID
		{
			get
			{
				return this._PID;
			}
			set
			{
				if ((this._PID != value))
				{
					this._PID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int")]
		public System.Nullable<int> ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="VarChar(100)")]
		public string Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this._Area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Controller", DbType="VarChar(100)")]
		public string Controller
		{
			get
			{
				return this._Controller;
			}
			set
			{
				if ((this._Controller != value))
				{
					this._Controller = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Action", DbType="VarChar(100)")]
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				if ((this._Action != value))
				{
					this._Action = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(10)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DefaultNamespace", DbType="VarChar(100)")]
		public string DefaultNamespace
		{
			get
			{
				return this._DefaultNamespace;
			}
			set
			{
				if ((this._DefaultNamespace != value))
				{
					this._DefaultNamespace = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_ScheduledTaskListGetResult
	{
		
		private System.Nullable<int> _ScheduledTaskId;
		
		private System.Nullable<System.Guid> _ScheduledTaskGuid;
		
		private System.Nullable<byte> _ScheduledTaskTypeId;
		
		private string _ScheduledTaskName;
		
		public Cloudcore_ScheduledTaskListGetResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskId", DbType="Int")]
		public System.Nullable<int> ScheduledTaskId
		{
			get
			{
				return this._ScheduledTaskId;
			}
			set
			{
				if ((this._ScheduledTaskId != value))
				{
					this._ScheduledTaskId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskGuid", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ScheduledTaskGuid
		{
			get
			{
				return this._ScheduledTaskGuid;
			}
			set
			{
				if ((this._ScheduledTaskGuid != value))
				{
					this._ScheduledTaskGuid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskTypeId", DbType="TinyInt")]
		public System.Nullable<byte> ScheduledTaskTypeId
		{
			get
			{
				return this._ScheduledTaskTypeId;
			}
			set
			{
				if ((this._ScheduledTaskTypeId != value))
				{
					this._ScheduledTaskTypeId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScheduledTaskName", DbType="VarChar(50)")]
		public string ScheduledTaskName
		{
			get
			{
				return this._ScheduledTaskName;
			}
			set
			{
				if ((this._ScheduledTaskName != value))
				{
					this._ScheduledTaskName = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_ServerInfoResult
	{
		
		private object _Servername;
		
		private string _Version;
		
		private object _ProductVersion;
		
		private object _ProductLevel;
		
		private object _Edition;
		
		public Cloudcore_ServerInfoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="servername", Storage="_Servername", DbType="sql_variant")]
		public object Servername
		{
			get
			{
				return this._Servername;
			}
			set
			{
				if ((this._Servername != value))
				{
					this._Servername = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="version", Storage="_Version", DbType="NVarChar(300)")]
		public string Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this._Version = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductVersion", DbType="sql_variant")]
		public object ProductVersion
		{
			get
			{
				return this._ProductVersion;
			}
			set
			{
				if ((this._ProductVersion != value))
				{
					this._ProductVersion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductLevel", DbType="sql_variant")]
		public object ProductLevel
		{
			get
			{
				return this._ProductLevel;
			}
			set
			{
				if ((this._ProductLevel != value))
				{
					this._ProductLevel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Edition", DbType="sql_variant")]
		public object Edition
		{
			get
			{
				return this._Edition;
			}
			set
			{
				if ((this._Edition != value))
				{
					this._Edition = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_SplitResult
	{
		
		private System.Nullable<int> _Id;
		
		private string _Item;
		
		public Cloudcore_SplitResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id", Storage="_Id", DbType="Int")]
		public System.Nullable<int> Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="item", Storage="_Item", DbType="VarChar(8000)")]
		public string Item
		{
			get
			{
				return this._Item;
			}
			set
			{
				if ((this._Item != value))
				{
					this._Item = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_SProcessDailyStatsResult
	{
		
		private System.Nullable<int> _ProcessModelId;
		
		private string _Weekday;
		
		private System.Nullable<int> _Week;
		
		private System.Nullable<System.DateTime> _Finished;
		
		private System.Nullable<int> _Completed;
		
		public Cloudcore_SProcessDailyStatsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProcessModelId", DbType="Int")]
		public System.Nullable<int> ProcessModelId
		{
			get
			{
				return this._ProcessModelId;
			}
			set
			{
				if ((this._ProcessModelId != value))
				{
					this._ProcessModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weekday", DbType="NVarChar(30)")]
		public string Weekday
		{
			get
			{
				return this._Weekday;
			}
			set
			{
				if ((this._Weekday != value))
				{
					this._Weekday = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Week", DbType="Int")]
		public System.Nullable<int> Week
		{
			get
			{
				return this._Week;
			}
			set
			{
				if ((this._Week != value))
				{
					this._Week = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Finished", DbType="Date")]
		public System.Nullable<System.DateTime> Finished
		{
			get
			{
				return this._Finished;
			}
			set
			{
				if ((this._Finished != value))
				{
					this._Finished = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Completed", DbType="Int")]
		public System.Nullable<int> Completed
		{
			get
			{
				return this._Completed;
			}
			set
			{
				if ((this._Completed != value))
				{
					this._Completed = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_SProcessTop10TaskAgeResult
	{
		
		private System.Nullable<int> _ActivityModelId;
		
		private string _ActivityName;
		
		private System.Nullable<int> _Age;
		
		public Cloudcore_SProcessTop10TaskAgeResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int")]
		public System.Nullable<int> ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50)")]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this._Age = value;
				}
			}
		}
	}
	
	public partial class Cloudcore_STaskSummaryResult
	{
		
		private System.Nullable<int> _ActivityModelId;
		
		private string _ActivityName;
		
		private System.Nullable<int> _PToday;
		
		private System.Nullable<int> _TToday;
		
		private System.Nullable<int> _PWeek;
		
		private System.Nullable<int> _TWeek;
		
		private System.Nullable<int> _PMonth;
		
		private System.Nullable<int> _TMonth;
		
		private System.Nullable<int> _PTodayPerc;
		
		private System.Nullable<int> _TTodayPerc;
		
		private System.Nullable<int> _RTodayPerc;
		
		private System.Nullable<int> _PWeekPerc;
		
		private System.Nullable<int> _TWeekPerc;
		
		private System.Nullable<int> _RWeekPerc;
		
		private System.Nullable<int> _PMonthPerc;
		
		private System.Nullable<int> _TMonthPerc;
		
		private System.Nullable<int> _RMonthPerc;
		
		public Cloudcore_STaskSummaryResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityModelId", DbType="Int")]
		public System.Nullable<int> ActivityModelId
		{
			get
			{
				return this._ActivityModelId;
			}
			set
			{
				if ((this._ActivityModelId != value))
				{
					this._ActivityModelId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityName", DbType="VarChar(50)")]
		public string ActivityName
		{
			get
			{
				return this._ActivityName;
			}
			set
			{
				if ((this._ActivityName != value))
				{
					this._ActivityName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PToday", DbType="Int")]
		public System.Nullable<int> PToday
		{
			get
			{
				return this._PToday;
			}
			set
			{
				if ((this._PToday != value))
				{
					this._PToday = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TToday", DbType="Int")]
		public System.Nullable<int> TToday
		{
			get
			{
				return this._TToday;
			}
			set
			{
				if ((this._TToday != value))
				{
					this._TToday = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PWeek", DbType="Int")]
		public System.Nullable<int> PWeek
		{
			get
			{
				return this._PWeek;
			}
			set
			{
				if ((this._PWeek != value))
				{
					this._PWeek = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TWeek", DbType="Int")]
		public System.Nullable<int> TWeek
		{
			get
			{
				return this._TWeek;
			}
			set
			{
				if ((this._TWeek != value))
				{
					this._TWeek = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PMonth", DbType="Int")]
		public System.Nullable<int> PMonth
		{
			get
			{
				return this._PMonth;
			}
			set
			{
				if ((this._PMonth != value))
				{
					this._PMonth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TMonth", DbType="Int")]
		public System.Nullable<int> TMonth
		{
			get
			{
				return this._TMonth;
			}
			set
			{
				if ((this._TMonth != value))
				{
					this._TMonth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PTodayPerc", DbType="Int")]
		public System.Nullable<int> PTodayPerc
		{
			get
			{
				return this._PTodayPerc;
			}
			set
			{
				if ((this._PTodayPerc != value))
				{
					this._PTodayPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TTodayPerc", DbType="Int")]
		public System.Nullable<int> TTodayPerc
		{
			get
			{
				return this._TTodayPerc;
			}
			set
			{
				if ((this._TTodayPerc != value))
				{
					this._TTodayPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RTodayPerc", DbType="Int")]
		public System.Nullable<int> RTodayPerc
		{
			get
			{
				return this._RTodayPerc;
			}
			set
			{
				if ((this._RTodayPerc != value))
				{
					this._RTodayPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PWeekPerc", DbType="Int")]
		public System.Nullable<int> PWeekPerc
		{
			get
			{
				return this._PWeekPerc;
			}
			set
			{
				if ((this._PWeekPerc != value))
				{
					this._PWeekPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TWeekPerc", DbType="Int")]
		public System.Nullable<int> TWeekPerc
		{
			get
			{
				return this._TWeekPerc;
			}
			set
			{
				if ((this._TWeekPerc != value))
				{
					this._TWeekPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RWeekPerc", DbType="Int")]
		public System.Nullable<int> RWeekPerc
		{
			get
			{
				return this._RWeekPerc;
			}
			set
			{
				if ((this._RWeekPerc != value))
				{
					this._RWeekPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PMonthPerc", DbType="Int")]
		public System.Nullable<int> PMonthPerc
		{
			get
			{
				return this._PMonthPerc;
			}
			set
			{
				if ((this._PMonthPerc != value))
				{
					this._PMonthPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TMonthPerc", DbType="Int")]
		public System.Nullable<int> TMonthPerc
		{
			get
			{
				return this._TMonthPerc;
			}
			set
			{
				if ((this._TMonthPerc != value))
				{
					this._TMonthPerc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RMonthPerc", DbType="Int")]
		public System.Nullable<int> RMonthPerc
		{
			get
			{
				return this._RMonthPerc;
			}
			set
			{
				if ((this._RMonthPerc != value))
				{
					this._RMonthPerc = value;
				}
			}
		}
	}
	
	public partial class Cloudcoremodel_ProcessModelCreateResult
	{
		
		private System.Nullable<int> _Column1;
		
		public Cloudcoremodel_ProcessModelCreateResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
    }
}
