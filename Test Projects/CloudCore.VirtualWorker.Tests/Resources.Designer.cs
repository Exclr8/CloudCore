﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudCore.VirtualWorker.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CloudCore.VirtualWorker.Tests.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from cloudcore.ScheduledTaskFailed
        ///go
        ///delete from cloudcore.ScheduledTask
        ///go
        ///delete from cloudcore.ScheduledTaskGroup
        ///go
        ///
        ///set identity_insert cloudcore.ScheduledTaskGroup on
        ///
        ///insert into [cloudcore].[ScheduledTaskGroup] (ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
        ///    select  ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId]
        ///    from    [cloudcore].[ScheduledTaskGroupB [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OrphanScheduledTasksCleanupText {
            get {
                return ResourceManager.GetString("OrphanScheduledTasksCleanupText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[cloudcore].[ScheduledTaskBackup]&apos;) AND type in (N&apos;U&apos;))
        ///DROP TABLE [cloudcore].ScheduledTaskBackup
        ///GO
        ///
        ///SET ANSI_NULLS ON
        ///GO
        ///
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///
        ///IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[cloudcore].[ScheduledTaskBackup]&apos;) AND type in (N&apos;U&apos;))
        ///BEGIN
        ///CREATE TABLE [cloudcore].[ScheduledTaskBackup](
        ///	[ScheduledTaskId] [int] NOT NULL,
        ///	[ScheduledTaskGuid] [uniqueidentifier] NOT NULL,
        ///	[Schedul [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OrphanScheduledTasksText {
            get {
                return ResourceManager.GetString("OrphanScheduledTasksText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from cloudcore.ActivityAllocation
        ///go
        ///
        ///delete from cloudcore.SystemApplicationAllocation
        ///go
        ///
        ///delete from cloudcore.WorklistFailure
        ///go
        ///
        ///delete from cloudcore.CostLedger
        ///go
        ///
        ///delete from cloudcore.Worklist
        ///go
        ///
        ///delete from cloudcoremodel.FlowModel
        ///go
        ///
        ///delete from cloudcore.ActivityFailureHistory
        ///go
        ///
        ///delete from cloudcore.ActivityHistory
        ///go
        ///
        ///delete from cloudcore.ProcessHistory
        ///go
        ///
        ///delete from cloudcore.Activity where ActivityId != 0
        ///go
        ///
        ///-- select * from cloudcoremodel.Activit [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ProcessDeploymentScriptText {
            get {
                return ResourceManager.GetString("ProcessDeploymentScriptText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @NumberOfInstancesDesired bigint = 400
        ///declare @ActivityGuidToStartWith uniqueidentifier = &apos;31BA9BF0-6BDB-4850-9A92-F9B82AE1B008&apos;
        ///
        ////*************** No need to modify beyond this line, unless fixing a bug ****************/
        ///
        ///declare @KeyValue bigint = 1, @UserId int = 0, @InstanceId bigint
        ///
        ///while @KeyValue &lt;= @NumberOfInstancesDesired
        ///begin
        ///	exec cloudcore.ActivityStart @ActivityGuidToStartWith, @KeyValue, @UserId, @InstanceId out
        ///	set @KeyValue = @KeyValue + 1
        ///end
        ///go.
        /// </summary>
        internal static string ProcessTestDataScriptText {
            get {
                return ResourceManager.GetString("ProcessTestDataScriptText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to declare @OldDate datetime = getdate() - 365
        ///
        ///update [cloudcore].[ScheduledTask] 
        ///set [Started] = @OldDate,
        ///    [StatusId] = 1, 
        ///    [Active] = 1,
        ///    [InitDate] = @OldDate, 
        ///    [NextRunDate] = @OldDate,
        ///    KeepAliveDate = @OldDate.
        /// </summary>
        internal static string RestoreOrphanScheduledTasksText {
            get {
                return ResourceManager.GetString("RestoreOrphanScheduledTasksText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete from cloudcore.ScheduledTaskFailed
        ///go
        ///delete from cloudcore.ScheduledTask
        ///go
        ///delete from cloudcore.ScheduledTaskGroup
        ///go
        ///
        ///declare @systemmoduleid int
        ///declare @scheduledtaskgroupguid uniqueidentifier = &apos;d2ba6fb1-832d-4d5f-b561-09fd5d5b7545&apos;
        ///declare @scheduledtaskgroupid int
        ///
        ///if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = &apos;6135587c-d2c4-4fe3-bfc6-5d5427a7720f&apos;)
        ///    begin
        ///      select @systemmoduleid = SystemModuleId
        ///      from    cloudcore.SystemModule
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ScheduledTasksText {
            get {
                return ResourceManager.GetString("ScheduledTasksText", resourceCulture);
            }
        }
    }
}
