<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d890652d-420d-4049-a8c8-0481554d2002" Description="CloudCore architect sub-process designer" Name="CloudCoreArchitectSubProcess" DisplayName="CloudCore - Architect Sub-Process Designer" Namespace="Architect" ProductName="CloudCore - Architect Sub-Process Designer" CompanyName="Framework One" PackageGuid="3a60313d-10af-44d3-b0c1-3cdbef0caa43" PackageNamespace="Architect" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="06c56b68-bfb9-468d-ac51-9125b0996686" Description="The root in which all other elements are embedded. Appears as a diagram." Name="SubProcess" DisplayName="Process" Namespace="Architect" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="19cf3e95-a2bc-417e-ae34-34c7c77f2019" Description="Description for Architect.SubProcess.Sub Process Name" Name="SubProcessName" DisplayName="Sub Process Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="387709dc-8e78-40ed-9301-c9ac8af936d3" Description="Description for Architect.SubProcess.Visio Id" Name="VisioId" DisplayName="Visio Id" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b5b2dbe4-761e-4954-8ac3-2f7bf932edd1" Description="Description for Architect.SubProcess.Process Ref" Name="ProcessRef" DisplayName="Process Ref" IsBrowsable="false" IsUIReadOnly="true">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.ModelBusReferenceTypeConverter)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.Picker.ModelReferenceEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="Microsoft.VisualStudio.Modeling.Integration.Picker.SupplyFileBasedBrowserConfiguration">
              <Parameters>
                <AttributeParameter Value="&quot;Choose a process file&quot;" />
                <AttributeParameter Value="&quot;Process file|*.process&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dee640a5-3db9-4229-bd10-c56edcc62470" Description="Description for Architect.SubProcess.Process Overview Sub Process Ref" Name="ProcessOverviewSubProcessRef" DisplayName="Process Overview Sub Process Ref">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.ModelBusReferenceTypeConverter)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.Picker.ModelElementReferenceEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="Microsoft.VisualStudio.Modeling.Integration.Picker.SupplyFileBasedBrowserConfiguration">
              <Parameters>
                <AttributeParameter Value="&quot;Choose a process file&quot;" />
                <AttributeParameter Value="&quot;Process file|*.process&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Activity" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SubProcessHasActivities.Activities</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="d87cdaff-43bd-47c0-8b28-5245bfb77ddb" Description="Description for Architect.Activity" Name="Activity" DisplayName="Activity" InheritanceModifier="Abstract" Namespace="Architect">
      <Properties>
        <DomainProperty Id="33f0fe34-452f-4289-944f-3fb9a049adba" Description="Description for Architect.Activity.Name" Name="Name" DisplayName="Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="19bb78f5-0919-4a52-aa62-ffac16b6eb0a" Description="Description for Architect.Activity.Is Menu Item" Name="IsMenuItem" DisplayName="Is Menu Item" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6783d102-fd81-4412-9e23-a265b5d784e3" Description="Description for Architect.Activity.Width" Name="Width" DisplayName="Width" DefaultValue="-1" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9d863635-79f2-4206-97f8-e33ca5e16efe" Description="Description for Architect.Activity.Height" Name="Height" DisplayName="Height" DefaultValue="-1" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e5cf09d8-e600-4c4b-ad69-13bf4501a2a8" Description="Description for Architect.Activity.Top" Name="Top" DisplayName="Top" DefaultValue="-1" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b2ea1d8b-6132-4ac9-a3ea-f24f2b971f2e" Description="Description for Architect.Activity.Left" Name="Left" DisplayName="Left" DefaultValue="-1" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="25dbaff7-590e-48e6-a9ff-bb576a191c65" Description="Description for Architect.Activity.Visio Id" Name="VisioId" DisplayName="Visio Id" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="5f82f344-c0e1-49ab-a5fd-ae8092eef643" Description="Rule makes a decision in the process" Name="WorkflowRule" DisplayName="Workflow Rule" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="9fe4d7e5-3dcb-4048-bc13-31b094911030" Description="Page has a web page linked to it for user input" Name="CloudcoreUser" DisplayName="Cloudcore User" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="UserActivity" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="198f7384-e7e7-4966-b8b2-75403bf707c3" Description="Description for Architect.CloudcoreUser.Doc Wait" Name="DocWait" DisplayName="Doc Wait">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="49e581f6-6265-4d71-8c9e-81603f00f765" Description="Used to do any database processing" Name="DatabaseEvent" DisplayName="Database Event" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="5522c94e-71b7-4e06-9c11-80bf4f9e2d6c" Description="Stop of process" Name="Stop" DisplayName="Stop" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Activity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="d02cc14f-feef-4124-afab-ea8b36bd02dd" Description="Start of a process" Name="Start" DisplayName="Stop" InheritanceModifier="Abstract" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Activity" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="f4a74cf4-cc4b-4361-9cf1-a1cd16b15e4e" Description="Description for Architect.Start.Is Startable" Name="IsStartable" DisplayName="Is Startable" DefaultValue="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="56190a22-90e5-480a-b249-2f292ccf5c22" Description="Description for Architect.DatabasePark" Name="DatabasePark" DisplayName="Database Park" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="1214b72f-ba1f-4d11-8fc6-1634509ab6b0" Description="Description for Architect.ToProcessConnector" Name="ToProcessConnector" DisplayName="To Process Connector" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Stop" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="620e58b7-02f7-4cc3-8ae0-a65e395491cc" Description="Description for Architect.ToProcessConnector.To Process Connector Ref" Name="ToProcessConnectorRef" DisplayName="To Process Connector Ref">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.ModelBusReferenceTypeConverter)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.Picker.ModelElementReferenceEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="Microsoft.VisualStudio.Modeling.Integration.Picker.SupplyFileBasedBrowserConfiguration">
              <Parameters>
                <AttributeParameter Value="&quot;Choose an activity in another subprocess &quot;" />
                <AttributeParameter Value="&quot;Subprocess file|*.subprocess&quot;" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="Microsoft.VisualStudio.Modeling.Integration.Picker.ApplyElementTypeLimitations">
              <Parameters>
                <AttributeParameter Value="typeof(WorkflowRule)" />
                <AttributeParameter Value="typeof(CloudcoreUser)" />
                <AttributeParameter Value="typeof(DatabaseEvent)" />
                <AttributeParameter Value="typeof(DatabasePark)" />
                <AttributeParameter Value="typeof(CloudPark)" />
                <AttributeParameter Value="typeof(CloudCustom)" />
                <AttributeParameter Value="typeof(PostageApp)" />
                <AttributeParameter Value="typeof(Clickatell)" />
                <AttributeParameter Value="typeof(DatabaseCosting)" />
                <AttributeParameter Value="typeof(CloudCosting)" />
                <AttributeParameter Value="typeof(DatabaseBatchStart)" />
                <AttributeParameter Value="typeof(CloudBatchStart)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8d866ff5-a7b1-4d06-b39e-e2594d9516ce" Description="Description for Architect.ToProcessConnector.External Activity Ref" Name="ExternalActivityRef" DisplayName="External Activity Ref" IsBrowsable="false">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.ModelBusReferenceTypeConverter)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.Picker.ModelElementReferenceEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="088eebd1-d0f4-460d-ab39-0e1b3912de16" Description="Description for Architect.ToProcessConnector.To Process Connector Name" Name="ToProcessConnectorName" DisplayName="To Process Connector Name" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="22271601-5387-4dfa-9d3b-baba28a86b9d" Description="Description for Architect.ToProcessConnector.To Activity Guid" Name="ToActivityGuid" DisplayName="To Activity Guid" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="76f6fd45-4520-4cbf-bca6-c8c0ae63269d" Description="Description for Architect.FromProcessConnector" Name="FromProcessConnector" DisplayName="From Process Connector" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Activity" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="a82b633c-10b9-4342-8cf2-0ca6b32814ad" Description="Description for Architect.FromProcessConnector.From Process Connector Ref" Name="FromProcessConnectorRef" DisplayName="From Process Connector Ref" IsBrowsable="false">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.ModelBusReferenceTypeConverter)" />
              </Parameters>
            </ClrAttribute>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Microsoft.VisualStudio.Modeling.Integration.Picker.ModelElementReferenceEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2d50834c-3c3b-492b-b8e0-809fecc79f92" Description="Description for Architect.FromProcessConnector.Can Delete" Name="CanDelete" DisplayName="Can Delete" DefaultValue="false" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d790692c-63b8-4b2e-99d9-f5126ef49788" Description="Description for Architect.FromProcessConnector.From Process Connector Name" Name="FromProcessConnectorName" DisplayName="From Process Connector Name" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="e23bfe4f-192b-4005-a5cb-f6b4350ae6f2" Description="Description for Architect.CloudCustom" Name="CloudCustom" DisplayName="Cloud Custom" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="UserActivity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="38d9d632-43b5-45d7-a6fd-c8ee3187b080" Description="Description for Architect.PostageApp" Name="PostageApp" DisplayName="PostageApp Activity" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="b5c41a36-0ea2-4be6-a91e-966d408cd654" Description="Description for Architect.Clickatell" Name="Clickatell" DisplayName="Clickatell Activity" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="126f6707-ad24-4b2b-90c9-9fc190eaa85b" Description="Description for Architect.DatabaseCosting" Name="DatabaseCosting" DisplayName="Database Costing" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="8c19a925-9c77-423d-acbd-633868fda8d6" Description="Description for Architect.CloudCosting" Name="CloudCosting" DisplayName="Cloud Costing" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="44bddc52-b3ff-418a-b68c-cea36235c1d6" Description="Description for Architect.DatabaseBatchStart" Name="DatabaseBatchStart" DisplayName="Database Batch Start" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="BaseBatchStart" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="96e1e20d-25f1-4503-b4c3-a6478aa0dc5a" Description="Description for Architect.CloudBatchStart" Name="CloudBatchStart" DisplayName="Cloud Batch Start" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="BaseBatchStart" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="a646dfbc-8ff2-4b60-8baf-d6dba6658187" Description="Description for Architect.CloudBatchWait" Name="CloudBatchWait" DisplayName="Cloud Batch Wait" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Activity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="70cb2751-0091-4848-817f-f5eed077296c" Description="Description for Architect.CloudPark" Name="CloudPark" DisplayName="Cloud Park" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="7a11a3c2-a5e2-4e96-a0e2-b058443bc07d" Description="Description for Architect.Corticon" Name="Corticon" DisplayName="Corticon" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="48904681-1c49-4920-89a5-b42b9fa4aae6" Description="Description for Architect.CustomUser" Name="CustomUser" DisplayName="Custom User" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="UserActivity" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="2058d9b8-5761-45b9-83b5-1480f2648d59" Description="Description for Architect.CustomUser.Doc Wait" Name="DocWait" DisplayName="Doc Wait">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="e701e1f1-91e1-415e-add6-f5e73256f14f" Description="Description for Architect.DatabaseBatchWait" Name="DatabaseBatchWait" DisplayName="Database Batch Wait" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Activity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="e9843189-a929-4fb3-a7aa-d40bbffecc16" Description="Description for Architect.BaseBatchStart" Name="BaseBatchStart" DisplayName="Base Batch Start" InheritanceModifier="Abstract" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3eb1bc0e-e559-4c30-95c4-b4035a2490fd" Description="Description for Architect.BaseBatchStart.Start Activity Guid" Name="StartActivityGuid" DisplayName="Start Activity Guid">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="241f5453-cdc2-4bd6-bb58-3751a69c9194" Description="Description for Architect.Email" Name="Email" DisplayName="Email" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="a01faf13-daf2-468c-80f3-c30927e001f9" Description="Description for Architect.MobileActivity" Name="MobileActivity" DisplayName="Mobile Activity" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="UserActivity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="eddf5d3f-f511-40c1-9df5-fdb7e066a84c" Description="Description for Architect.HybridActivity" Name="HybridActivity" DisplayName="Hybrid Activity" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="UserActivity" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="a3b134e1-9808-484a-8667-37c155844990" Description="Description for Architect.UserActivity" Name="UserActivity" DisplayName="User Activity" Namespace="Architect">
      <BaseClass>
        <DomainClassMoniker Name="Start" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3e7f7c8e-113b-400d-983f-4f2bb8170a51" Description="Description for Architect.UserActivity.Only Visible At Location" Name="OnlyVisibleAtLocation" DisplayName="Only Visible At Location" DefaultValue="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7c462b31-e834-4a43-90c9-a4e6930f2f1e" Description="Description for Architect.UserActivity.Location Radius" Name="LocationRadius" DisplayName="Location Radius">
          <Type>
            <ExternalTypeMoniker Name="/System/Int32" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="4c788070-a372-4928-a7c6-3956f08c0d07" Description="Description for Architect.Flow" Name="Flow" DisplayName="Flow" Namespace="Architect" AllowsDuplicates="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="FlowBase" />
      </BaseRelationship>
      <Properties>
        <DomainProperty Id="c31ca12e-a32b-49dd-aa8e-658de58886e6" Description="Description for Architect.Flow.Outcome" Name="Outcome" DisplayName="Outcome" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ae1a76d5-3407-453a-8aeb-37726b8de12b" Description="Description for Architect.Flow.Storyline" Name="Storyline" DisplayName="Storyline">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="7ed08450-7c01-43dc-8096-502dc46231c2" Description="Description for Architect.Flow.SourceActivity" Name="SourceActivity" DisplayName="Source Activity" PropertyName="TargetActivities" PropertyDisplayName="Target Activities">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="598daa36-3ecc-430b-bb0d-0d6c55597f11" Description="Description for Architect.Flow.TargetActivity" Name="TargetActivity" DisplayName="Target Activity" PropertyName="SourceActivities" PropertyDisplayName="Source Activities">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="960e6465-a7b3-4df7-b988-b90c94fa3425" Description="Description for Architect.FlowMinimal" Name="FlowMinimal" DisplayName="Flow Minimal" Namespace="Architect">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="FlowBase" />
      </BaseRelationship>
      <Properties>
        <DomainProperty Id="ac365f78-fa0e-4012-b10d-a1fb8ea2c27d" Description="Description for Architect.FlowMinimal.Outcome" Name="Outcome" DisplayName="Outcome" DefaultValue="-" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ffab6b5a-697b-46cc-92a8-8ffab3aedb73" Description="Description for Architect.FlowMinimal.Storyline" Name="Storyline" DisplayName="Storyline">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="2110a81a-6216-480d-8cb2-6f524f412937" Description="Description for Architect.FlowMinimal.SActivity" Name="SActivity" DisplayName="SActivity" PropertyName="TActivity" PropertyDisplayName="TActivity">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6179bd5e-2b59-40ad-9ab1-9d4768a3bfe5" Description="Description for Architect.FlowMinimal.TActivity" Name="TActivity" DisplayName="TActivity" PropertyName="SActivity" PropertyDisplayName="SActivity">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b2cf30d2-9c50-4e06-8a33-c3ddd0561a4f" Description="Flow between activities" Name="FlowBase" DisplayName="Flow" Namespace="Architect" AllowsDuplicates="true">
      <Properties>
        <DomainProperty Id="fbe41b58-071e-4f9c-96cd-b12424a1bc29" Description="Description for Architect.FlowBase.Type" Name="Type" DisplayName="Type" DefaultValue="none">
          <Type>
            <DomainEnumerationMoniker Name="FlowType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="53a70fb9-e90b-48fa-aeda-87a9f910e065" Description="Description for Architect.FlowBase.Visio Id" Name="VisioId" DisplayName="Visio Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="76f26956-c6bb-46ff-a068-cddec96da14d" Description="Description for Architect.FlowBase.SourceActivity" Name="SourceActivity" DisplayName="Source Activity" PropertyName="TargetActs" PropertyDisplayName="Target Acts">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="029f3254-90c8-4487-b1b7-764a79086110" Description="Description for Architect.FlowBase.TargetActivity" Name="TargetActivity" DisplayName="Target Activity" PropertyName="SourceActs" PropertyDisplayName="Source Acts">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="dc61d3e6-ae45-4c5a-bc96-6060eb16918e" Description="Description for Architect.SubProcessHasActivities" Name="SubProcessHasActivities" DisplayName="Sub Process Has Activities" Namespace="Architect" IsEmbedding="true">
      <Source>
        <DomainRole Id="9a0a417f-7b36-4284-9884-e125dc7e4451" Description="Description for Architect.SubProcessHasActivities.SubProcess" Name="SubProcess" DisplayName="Sub Process" PropertyName="Activities" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Activities">
          <RolePlayer>
            <DomainClassMoniker Name="SubProcess" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6f109727-0e66-49ce-bc7d-8d23e9a641ca" Description="Description for Architect.SubProcessHasActivities.Activity" Name="Activity" DisplayName="Activity" PropertyName="SubProcess" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Sub Process">
          <RolePlayer>
            <DomainClassMoniker Name="Activity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <ExternalType Name="List&lt;System.Int32&gt;" Namespace="System.Collections.Generic" />
    <DomainEnumeration Name="YesNo" Namespace="Architect" Description="Description for Architect.YesNo">
      <Literals>
        <EnumerationLiteral Description="Description for Architect.YesNo.Yes" Name="Yes" Value="1" />
        <EnumerationLiteral Description="Description for Architect.YesNo.No" Name="No" Value="0" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="Color" Namespace="System.Drawing" />
    <DomainEnumeration Name="FlowType" Namespace="Architect" Description="Description for Architect.FlowType">
      <Literals>
        <EnumerationLiteral Description="Description for Architect.FlowType.none" Name="none" Value="0" />
        <EnumerationLiteral Description="Description for Architect.FlowType.Optimal" Name="Optimal" Value="1" />
        <EnumerationLiteral Description="Description for Architect.FlowType.Negative" Name="Negative" Value="2" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="ModelBusReference" Namespace="Microsoft.VisualStudio.Modeling.Integration" />
    <ExternalType Name="List&lt;System.Guid&gt;" Namespace="System.Collections.Generic" />
  </Types>
  <Shapes>
    <ImageShape Id="26251b32-204a-40d9-96a8-b3b12b07ff7e" Description="Rule makes a decision in the process" Name="WorkflowRuleShape" DisplayName="Rule" Namespace="Architect" FixedTooltipText="Workflow Rule Shape" InitialWidth="1.2395" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Flow.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="d0788675-d3a4-4539-b34f-ed82ff0668ac" Description="Page has a web page linked to it for user input" Name="PageShape" DisplayName="Page" Namespace="Architect" FixedTooltipText="Page Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\UserActivity.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="UserActivityShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="27780486-1d36-4f6c-80dc-d5d1c57ff595" Description="Used to do any database processing" Name="SQLEventShape" DisplayName="Event" Namespace="Architect" FixedTooltipText="SQLEvent Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\CustomEvent-SQL.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="79c6ddbe-890e-4503-85f6-633ac2a02cd0" Description="Stop of process" Name="StopShape" DisplayName="Stop" Namespace="Architect" FixedTooltipText="Stop Shape" InitialWidth="0.565" InitialHeight="0.54175" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Stop.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="d721d810-c82d-4453-a308-c9e2f794a04c" Description="Parked DB Activity" Name="SQLParkShape" DisplayName="DB Parked" Namespace="Architect" FixedTooltipText="SQLPark Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Parked-SQL.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="21443752-ab6f-4f07-92dd-6e36856ecfbf" Description="Description for Architect.BaseActivityShape" Name="BaseActivityShape" DisplayName="Base Activity Shape" Namespace="Architect" FixedTooltipText="Base Activity Shape" InitialWidth="0.83675" InitialHeight="0.83675" HasDefaultConnectionPoints="true" Image="Resources\Shapes\UserActivity.png" />
    <ImageShape Id="d2eda5fd-c05a-4ac5-ae16-404017889700" Description="Description for Architect.ToProcessConnectorShape" Name="ToProcessConnectorShape" DisplayName="To Process Connector Shape" Namespace="Architect" FixedTooltipText="To Process Connector Shape" InitialWidth="0.565" InitialHeight="0.54175" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Outgoing.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="b6e909ef-0a8b-47a9-b745-2e784d0df84e" Description="Description for Architect.FromProcessConnectorShape" Name="FromProcessConnectorShape" DisplayName="From Process Connector Shape" Namespace="Architect" FixedTooltipText="From Process Connector Shape" InitialWidth="0.565" InitialHeight="0.54175" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Incoming.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="55bd715c-4a05-4307-b966-7d257549a513" Description="Description for Architect.CSharpEventShape" Name="CSharpEventShape" DisplayName="CSharp Event Shape" Namespace="Architect" FixedTooltipText="CSharp Event Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\CustomEvent-C#.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="9cd2aceb-bf38-4c6a-8d19-1675b3fd822a" Description="Description for Architect.PostageAppShape" Name="PostageAppShape" DisplayName="Postage App Shape" Namespace="Architect" FixedTooltipText="Postage App Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\PostageAppActivity.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="11d8ffa3-744f-4d0f-b9a4-94b649181b8d" Description="Description for Architect.ClickatellShape" Name="ClickatellShape" DisplayName="Clickatell" Namespace="Architect" FixedTooltipText="Clickatell Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\ClickatellActivity.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="918b9f73-7520-48db-b92a-06df5d9dbad9" Description="Description for Architect.SQLCostingShape" Name="SQLCostingShape" DisplayName="Cost DB" Namespace="Architect" FixedTooltipText="Cost DB" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Costing-SQL.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="ea921963-1273-4fb1-95a7-bb0836266bda" Description="Description for Architect.CSharpCostingShape" Name="CSharpCostingShape" DisplayName="CSharp Costing Shape" Namespace="Architect" FixedTooltipText="CSharp Costing Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Costing-C#.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="0376084b-5105-47b1-9ee1-24ed5da0c8b3" Description="Description for Architect.SQLBatchStartShape" Name="SQLBatchStartShape" DisplayName="SQLBatch Start Shape" Namespace="Architect" FixedTooltipText="SQLBatch Start Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\BatchStart-SQL.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="d0dfc027-b36a-4291-83b5-02b519ea3ca7" Description="Description for Architect.CSharpBatchStartShape" Name="CSharpBatchStartShape" DisplayName="CSharp Batch Start Shape" Namespace="Architect" FixedTooltipText="CSharp Batch Start Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\BatchStart-C#.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="359dbdb8-a2fb-4fbf-b16c-fd755ea345c3" Description="Description for Architect.BatchWaitShape" Name="BatchWaitShape" DisplayName="Batch Wait Shape" Namespace="Architect" FixedTooltipText="Batch Wait Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\BatchWait-C#.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="SubProcessGuid" DisplayName="" DefaultText="" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="f9b35e43-78c3-4820-a689-03dff1da087e" Description="Description for Architect.CSharpParkShape" Name="CSharpParkShape" DisplayName="CSharp Park Shape" Namespace="Architect" FixedTooltipText="CSharp Park Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\Parked-C#.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="3a94e819-6633-4efb-9d4c-af832a470f6f" Description="Description for Architect.CorticonShape" Name="CorticonShape" DisplayName="Corticon Shape" Namespace="Architect" FixedTooltipText="Corticon Shape" InitialWidth="1.243" InitialHeight="0.84025" HasDefaultConnectionPoints="true" Image="Resources\Shapes\Corticon.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="12bbcaa2-2f1f-4d9b-8e76-6cdf46830626" Description="Description for Architect.StartableShape" Name="StartableShape" DisplayName="Startable Shape" Namespace="Architect" FixedTooltipText="Startable Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\UserActivity.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0.005" VerticalOffset="0">
        <IconDecorator Name="IsStartableIconDecorator" DisplayName="Is Startable Icon Decorator" DefaultIcon="Resources\Shapes\SmallStart.png" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="19a6d1d4-782b-494c-b209-9c55a02dbdd8" Description="Description for Architect.CustomUserShape" Name="CustomUserShape" DisplayName="Custom User Shape" Namespace="Architect" FixedTooltipText="Custom User Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\UserActivity2.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="UserActivityShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="833d05c9-822c-4069-bce1-e0a1e408159c" Description="Description for Architect.DatabaseBatchWaitShape" Name="DatabaseBatchWaitShape" DisplayName="Database Batch Wait Shape" Namespace="Architect" FixedTooltipText="Database Batch Wait Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\BatchWait-SQL.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="SubProcessGuid" DisplayName="" DefaultText="" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="6ee1597c-6ecd-4368-98f1-bfa861863378" Description="Description for Architect.EmailShape" Name="EmailShape" DisplayName="Email Shape" Namespace="Architect" FixedTooltipText="Email Shape" InitialWidth="1.243" InitialHeight="0.84025" Image="Resources\Shapes\Email.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="fd5b3023-e68b-4839-8628-0e439b388679" Description="Description for Architect.MobileShape" Name="MobileShape" DisplayName="Mobile Shape" Namespace="Architect" FixedTooltipText="Mobile Shape" InitialHeight="1" Image="Resources\Shapes\UserActivityMobile.jpg">
      <BaseImageShape>
        <ImageShapeMoniker Name="UserActivityShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="413fceca-752f-4cf2-b209-69a95e19f2fb" Description="Description for Architect.HybridShape" Name="HybridShape" DisplayName="Hybrid Shape" Namespace="Architect" FixedTooltipText="Hybrid Shape" InitialHeight="1" Image="Resources\Shapes\UserActivityHybrid.jpg">
      <BaseImageShape>
        <ImageShapeMoniker Name="UserActivityShape" />
      </BaseImageShape>
    </ImageShape>
    <ImageShape Id="7003ffa6-bf6a-4a7f-9bc5-77f8cd7ec9a4" Description="Description for Architect.UserActivityShape" Name="UserActivityShape" DisplayName="User Activity Shape" Namespace="Architect" FixedTooltipText="User Activity Shape" InitialHeight="1" Image="Resources\Shapes\UserActivity.png">
      <BaseImageShape>
        <ImageShapeMoniker Name="StartableShape" />
      </BaseImageShape>
      <ShapeHasDecorators Position="InnerMiddleRight" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="OnlyVisibleAtLocation" DisplayName="Only Visible At Location" DefaultIcon="Resources\Shapes\SmallLocation.png" />
      </ShapeHasDecorators>
    </ImageShape>
  </Shapes>
  <Connectors>
    <Connector Id="4392f9a0-155a-459f-b692-6b2a5e42cb2e" Description="Flow between activities" Name="FlowConnector" DisplayName="Flow" Namespace="Architect" FixedTooltipText="Flow" Color="White" TargetEndStyle="FilledArrow" Thickness="0.05" ExposesColorAsProperty="true" targetEndWidth="0.17" targetEndHeight="0.16">
      <Properties>
        <DomainProperty Id="95df0099-f4de-4d54-b6bd-84a760c97fa9" Description="Description for Architect.FlowConnector.Color" Name="Color" DisplayName="Color" Kind="CustomStorage" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
      </Properties>
      <ConnectorHasDecorators Position="TargetBottom" OffsetFromShape="-0.02" OffsetFromLine="-0.02" isMoveable="true">
        <TextDecorator Name="OutcomeDecorator" DisplayName="Outcome Decorator" DefaultText="Outcome" FontSize="10" />
      </ConnectorHasDecorators>
    </Connector>
    <Connector Id="324d9e41-d494-4741-bd1f-c2a92f9993f8" Description="Flow between activities" Name="FlowMinimalConnector" DisplayName="Flow" Namespace="Architect" FixedTooltipText="Flow" Color="White" TargetEndStyle="FilledArrow" Thickness="0.05" ExposesColorAsProperty="true" targetEndWidth="0.17" targetEndHeight="0.16">
      <Properties>
        <DomainProperty Id="5480f3a0-d4c7-4c64-88c9-fee677cc7833" Description="Description for Architect.FlowMinimalConnector.Color" Name="Color" DisplayName="Color" Kind="CustomStorage" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
      </Properties>
    </Connector>
  </Connectors>
  <XmlSerializationBehavior Name="CloudCoreArchitectSubProcessSerializationBehavior" Namespace="Architect">
    <ClassData>
      <XmlClassData TypeName="SubProcess" MonikerAttributeName="" SerializeId="true" MonikerElementName="BTProcessMoniker" ElementName="BTProcess" MonikerTypeName="SubProcessMoniker">
        <DomainClassMoniker Name="SubProcess" />
        <ElementData>
          <XmlPropertyData XmlName="subProcessName">
            <DomainPropertyMoniker Name="SubProcess/SubProcessName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visioId">
            <DomainPropertyMoniker Name="SubProcess/VisioId" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="activities">
            <DomainRelationshipMoniker Name="SubProcessHasActivities" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="processRef">
            <DomainPropertyMoniker Name="SubProcess/ProcessRef" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="processOverviewSubProcessRef">
            <DomainPropertyMoniker Name="SubProcess/ProcessOverviewSubProcessRef" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="FlowConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="flowConnectorMoniker" ElementName="flowConnector" MonikerTypeName="FlowConnectorMoniker">
        <ConnectorMoniker Name="FlowConnector" />
        <ElementData>
          <XmlPropertyData XmlName="color">
            <DomainPropertyMoniker Name="FlowConnector/Color" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SubProcessDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="SubProcessDiagramMoniker" ElementName="SubProcessDiagram" MonikerTypeName="SubProcessDiagramMoniker">
        <DiagramMoniker Name="SubProcessDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Activity" MonikerAttributeName="" SerializeId="true" MonikerElementName="ActivityMoniker" ElementName="Activity" MonikerTypeName="ActivityMoniker">
        <DomainClassMoniker Name="Activity" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Activity/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isMenuItem">
            <DomainPropertyMoniker Name="Activity/IsMenuItem" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetActivities">
            <DomainRelationshipMoniker Name="Flow" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="TBTActivity">
            <DomainRelationshipMoniker Name="FlowMinimal" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetActs">
            <DomainRelationshipMoniker Name="FlowBase" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="width">
            <DomainPropertyMoniker Name="Activity/Width" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="height">
            <DomainPropertyMoniker Name="Activity/Height" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="top">
            <DomainPropertyMoniker Name="Activity/Top" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="left">
            <DomainPropertyMoniker Name="Activity/Left" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visioId">
            <DomainPropertyMoniker Name="Activity/VisioId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Flow" MonikerAttributeName="" SerializeId="true" MonikerElementName="flowMoniker" ElementName="flow" MonikerTypeName="FlowMoniker">
        <DomainRelationshipMoniker Name="Flow" />
        <ElementData>
          <XmlPropertyData XmlName="outcome">
            <DomainPropertyMoniker Name="Flow/Outcome" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="storyline">
            <DomainPropertyMoniker Name="Flow/Storyline" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="WorkflowRule" MonikerAttributeName="" SerializeId="true" MonikerElementName="BTRuleMoniker" ElementName="BTRule" MonikerTypeName="WorkflowRuleMoniker">
        <DomainClassMoniker Name="WorkflowRule" />
      </XmlClassData>
      <XmlClassData TypeName="CloudcoreUser" MonikerAttributeName="" SerializeId="true" MonikerElementName="BTPageMoniker" ElementName="BTPage" MonikerTypeName="CloudcoreUserMoniker">
        <DomainClassMoniker Name="CloudcoreUser" />
        <ElementData>
          <XmlPropertyData XmlName="docWait">
            <DomainPropertyMoniker Name="CloudcoreUser/DocWait" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DatabaseEvent" MonikerAttributeName="" SerializeId="true" MonikerElementName="EventMoniker" ElementName="Event" MonikerTypeName="DatabaseEventMoniker">
        <DomainClassMoniker Name="DatabaseEvent" />
      </XmlClassData>
      <XmlClassData TypeName="Stop" MonikerAttributeName="" SerializeId="true" MonikerElementName="BTStopMoniker" ElementName="BTStop" MonikerTypeName="StopMoniker">
        <DomainClassMoniker Name="Stop" />
      </XmlClassData>
      <XmlClassData TypeName="WorkflowRuleShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="workflowRuleShapeMoniker" ElementName="workflowRuleShape" MonikerTypeName="WorkflowRuleShapeMoniker">
        <ImageShapeMoniker Name="WorkflowRuleShape" />
      </XmlClassData>
      <XmlClassData TypeName="PageShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="pageShapeMoniker" ElementName="pageShape" MonikerTypeName="PageShapeMoniker">
        <ImageShapeMoniker Name="PageShape" />
      </XmlClassData>
      <XmlClassData TypeName="SQLEventShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="sQLEventShapeMoniker" ElementName="sQLEventShape" MonikerTypeName="SQLEventShapeMoniker">
        <ImageShapeMoniker Name="SQLEventShape" />
      </XmlClassData>
      <XmlClassData TypeName="StopShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="stopShapeMoniker" ElementName="stopShape" MonikerTypeName="StopShapeMoniker">
        <ImageShapeMoniker Name="StopShape" />
      </XmlClassData>
      <XmlClassData TypeName="FlowMinimal" MonikerAttributeName="" SerializeId="true" MonikerElementName="flowMinimalMoniker" ElementName="flowMinimal" MonikerTypeName="FlowMinimalMoniker">
        <DomainRelationshipMoniker Name="FlowMinimal" />
        <ElementData>
          <XmlPropertyData XmlName="outcome">
            <DomainPropertyMoniker Name="FlowMinimal/Outcome" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="storyline">
            <DomainPropertyMoniker Name="FlowMinimal/Storyline" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="FlowMinimalConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="flowMinimalConnectorMoniker" ElementName="flowMinimalConnector" MonikerTypeName="FlowMinimalConnectorMoniker">
        <ConnectorMoniker Name="FlowMinimalConnector" />
        <ElementData>
          <XmlPropertyData XmlName="color">
            <DomainPropertyMoniker Name="FlowMinimalConnector/Color" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Start" MonikerAttributeName="" SerializeId="true" MonikerElementName="BTStartMoniker" ElementName="BTStart" MonikerTypeName="StartMoniker">
        <DomainClassMoniker Name="Start" />
        <ElementData>
          <XmlPropertyData XmlName="isStartable">
            <DomainPropertyMoniker Name="Start/IsStartable" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="FlowBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="flowBaseMoniker" ElementName="flowBase" MonikerTypeName="FlowBaseMoniker">
        <DomainRelationshipMoniker Name="FlowBase" />
        <ElementData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="FlowBase/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visioId">
            <DomainPropertyMoniker Name="FlowBase/VisioId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DatabasePark" MonikerAttributeName="" SerializeId="true" MonikerElementName="databaseParkMoniker" ElementName="databasePark" MonikerTypeName="DatabaseParkMoniker">
        <DomainClassMoniker Name="DatabasePark" />
      </XmlClassData>
      <XmlClassData TypeName="SQLParkShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="sQLParkShapeMoniker" ElementName="sQLParkShape" MonikerTypeName="SQLParkShapeMoniker">
        <ImageShapeMoniker Name="SQLParkShape" />
      </XmlClassData>
      <XmlClassData TypeName="BaseActivityShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="baseActivityShapeMoniker" ElementName="baseActivityShape" MonikerTypeName="BaseActivityShapeMoniker">
        <ImageShapeMoniker Name="BaseActivityShape" />
      </XmlClassData>
      <XmlClassData TypeName="SubProcessHasActivities" MonikerAttributeName="" SerializeId="true" MonikerElementName="subProcessHasActivitiesMoniker" ElementName="subProcessHasActivities" MonikerTypeName="SubProcessHasActivitiesMoniker">
        <DomainRelationshipMoniker Name="SubProcessHasActivities" />
      </XmlClassData>
      <XmlClassData TypeName="ToProcessConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="toProcessConnectorMoniker" ElementName="toProcessConnector" MonikerTypeName="ToProcessConnectorMoniker">
        <DomainClassMoniker Name="ToProcessConnector" />
        <ElementData>
          <XmlPropertyData XmlName="toProcessConnectorRef">
            <DomainPropertyMoniker Name="ToProcessConnector/ToProcessConnectorRef" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="externalActivityRef">
            <DomainPropertyMoniker Name="ToProcessConnector/ExternalActivityRef" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="toProcessConnectorName">
            <DomainPropertyMoniker Name="ToProcessConnector/ToProcessConnectorName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="toActivityGuid">
            <DomainPropertyMoniker Name="ToProcessConnector/ToActivityGuid" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ToProcessConnectorShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="toProcessConnectorShapeMoniker" ElementName="toProcessConnectorShape" MonikerTypeName="ToProcessConnectorShapeMoniker">
        <ImageShapeMoniker Name="ToProcessConnectorShape" />
      </XmlClassData>
      <XmlClassData TypeName="FromProcessConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="fromProcessConnectorMoniker" ElementName="fromProcessConnector" MonikerTypeName="FromProcessConnectorMoniker">
        <DomainClassMoniker Name="FromProcessConnector" />
        <ElementData>
          <XmlPropertyData XmlName="fromProcessConnectorRef">
            <DomainPropertyMoniker Name="FromProcessConnector/FromProcessConnectorRef" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="canDelete">
            <DomainPropertyMoniker Name="FromProcessConnector/CanDelete" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="fromProcessConnectorName">
            <DomainPropertyMoniker Name="FromProcessConnector/FromProcessConnectorName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="FromProcessConnectorShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="fromProcessConnectorShapeMoniker" ElementName="fromProcessConnectorShape" MonikerTypeName="FromProcessConnectorShapeMoniker">
        <ImageShapeMoniker Name="FromProcessConnectorShape" />
      </XmlClassData>
      <XmlClassData TypeName="CSharpEventShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="cSharpEventShapeMoniker" ElementName="cSharpEventShape" MonikerTypeName="CSharpEventShapeMoniker">
        <ImageShapeMoniker Name="CSharpEventShape" />
      </XmlClassData>
      <XmlClassData TypeName="CloudCustom" MonikerAttributeName="" SerializeId="true" MonikerElementName="cloudCustomMoniker" ElementName="cloudCustom" MonikerTypeName="CloudCustomMoniker">
        <DomainClassMoniker Name="CloudCustom" />
      </XmlClassData>
      <XmlClassData TypeName="PostageAppShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="postageAppShapeMoniker" ElementName="postageAppShape" MonikerTypeName="PostageAppShapeMoniker">
        <ImageShapeMoniker Name="PostageAppShape" />
      </XmlClassData>
      <XmlClassData TypeName="PostageApp" MonikerAttributeName="" SerializeId="true" MonikerElementName="PostageAppMoniker" ElementName="PostageApp" MonikerTypeName="PostageAppMoniker">
        <DomainClassMoniker Name="PostageApp" />
      </XmlClassData>
      <XmlClassData TypeName="Clickatell" MonikerAttributeName="" SerializeId="true" MonikerElementName="clickatellMoniker" ElementName="clickatell" MonikerTypeName="ClickatellMoniker">
        <DomainClassMoniker Name="Clickatell" />
      </XmlClassData>
      <XmlClassData TypeName="ClickatellShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="clickatellShapeMoniker" ElementName="clickatellShape" MonikerTypeName="ClickatellShapeMoniker">
        <ImageShapeMoniker Name="ClickatellShape" />
      </XmlClassData>
      <XmlClassData TypeName="DatabaseCosting" MonikerAttributeName="" SerializeId="true" MonikerElementName="databaseCostingMoniker" ElementName="databaseCosting" MonikerTypeName="DatabaseCostingMoniker">
        <DomainClassMoniker Name="DatabaseCosting" />
      </XmlClassData>
      <XmlClassData TypeName="SQLCostingShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="sQLCostingShapeMoniker" ElementName="sQLCostingShape" MonikerTypeName="SQLCostingShapeMoniker">
        <ImageShapeMoniker Name="SQLCostingShape" />
      </XmlClassData>
      <XmlClassData TypeName="CloudCosting" MonikerAttributeName="" SerializeId="true" MonikerElementName="cloudCostingMoniker" ElementName="cloudCosting" MonikerTypeName="CloudCostingMoniker">
        <DomainClassMoniker Name="CloudCosting" />
      </XmlClassData>
      <XmlClassData TypeName="CSharpCostingShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="cSharpCostingShapeMoniker" ElementName="cSharpCostingShape" MonikerTypeName="CSharpCostingShapeMoniker">
        <ImageShapeMoniker Name="CSharpCostingShape" />
      </XmlClassData>
      <XmlClassData TypeName="DatabaseBatchStart" MonikerAttributeName="" SerializeId="true" MonikerElementName="databaseBatchStartMoniker" ElementName="databaseBatchStart" MonikerTypeName="DatabaseBatchStartMoniker">
        <DomainClassMoniker Name="DatabaseBatchStart" />
      </XmlClassData>
      <XmlClassData TypeName="CloudBatchStart" MonikerAttributeName="" SerializeId="true" MonikerElementName="cloudBatchStartMoniker" ElementName="cloudBatchStart" MonikerTypeName="CloudBatchStartMoniker">
        <DomainClassMoniker Name="CloudBatchStart" />
      </XmlClassData>
      <XmlClassData TypeName="CloudBatchWait" MonikerAttributeName="" SerializeId="true" MonikerElementName="cloudBatchWaitMoniker" ElementName="cloudBatchWait" MonikerTypeName="CloudBatchWaitMoniker">
        <DomainClassMoniker Name="CloudBatchWait" />
      </XmlClassData>
      <XmlClassData TypeName="SQLBatchStartShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="sQLBatchStartShapeMoniker" ElementName="sQLBatchStartShape" MonikerTypeName="SQLBatchStartShapeMoniker">
        <ImageShapeMoniker Name="SQLBatchStartShape" />
      </XmlClassData>
      <XmlClassData TypeName="CSharpBatchStartShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="cSharpBatchStartShapeMoniker" ElementName="cSharpBatchStartShape" MonikerTypeName="CSharpBatchStartShapeMoniker">
        <ImageShapeMoniker Name="CSharpBatchStartShape" />
      </XmlClassData>
      <XmlClassData TypeName="BatchWaitShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="batchWaitShapeMoniker" ElementName="batchWaitShape" MonikerTypeName="BatchWaitShapeMoniker">
        <ImageShapeMoniker Name="BatchWaitShape" />
      </XmlClassData>
      <XmlClassData TypeName="CloudPark" MonikerAttributeName="" SerializeId="true" MonikerElementName="cloudParkMoniker" ElementName="cloudPark" MonikerTypeName="CloudParkMoniker">
        <DomainClassMoniker Name="CloudPark" />
      </XmlClassData>
      <XmlClassData TypeName="CSharpParkShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="cSharpParkShapeMoniker" ElementName="cSharpParkShape" MonikerTypeName="CSharpParkShapeMoniker">
        <ImageShapeMoniker Name="CSharpParkShape" />
      </XmlClassData>
      <XmlClassData TypeName="Corticon" MonikerAttributeName="" SerializeId="true" MonikerElementName="corticonMoniker" ElementName="corticon" MonikerTypeName="CorticonMoniker">
        <DomainClassMoniker Name="Corticon" />
      </XmlClassData>
      <XmlClassData TypeName="CorticonShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="corticonShapeMoniker" ElementName="corticonShape" MonikerTypeName="CorticonShapeMoniker">
        <ImageShapeMoniker Name="CorticonShape" />
      </XmlClassData>
      <XmlClassData TypeName="StartableShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="startableShapeMoniker" ElementName="startableShape" MonikerTypeName="StartableShapeMoniker">
        <ImageShapeMoniker Name="StartableShape" />
      </XmlClassData>
      <XmlClassData TypeName="CustomUser" MonikerAttributeName="" SerializeId="true" MonikerElementName="customUserMoniker" ElementName="customUser" MonikerTypeName="CustomUserMoniker">
        <DomainClassMoniker Name="CustomUser" />
        <ElementData>
          <XmlPropertyData XmlName="docWait">
            <DomainPropertyMoniker Name="CustomUser/DocWait" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CustomUserShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="customUserShapeMoniker" ElementName="customUserShape" MonikerTypeName="CustomUserShapeMoniker">
        <ImageShapeMoniker Name="CustomUserShape" />
      </XmlClassData>
      <XmlClassData TypeName="DatabaseBatchWait" MonikerAttributeName="" SerializeId="true" MonikerElementName="databaseBatchWaitMoniker" ElementName="databaseBatchWait" MonikerTypeName="DatabaseBatchWaitMoniker">
        <DomainClassMoniker Name="DatabaseBatchWait" />
      </XmlClassData>
      <XmlClassData TypeName="DatabaseBatchWaitShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="databaseBatchWaitShapeMoniker" ElementName="databaseBatchWaitShape" MonikerTypeName="DatabaseBatchWaitShapeMoniker">
        <ImageShapeMoniker Name="DatabaseBatchWaitShape" />
      </XmlClassData>
      <XmlClassData TypeName="BaseBatchStart" MonikerAttributeName="" SerializeId="true" MonikerElementName="baseBatchStartMoniker" ElementName="baseBatchStart" MonikerTypeName="BaseBatchStartMoniker">
        <DomainClassMoniker Name="BaseBatchStart" />
        <ElementData>
          <XmlPropertyData XmlName="startActivityGuid">
            <DomainPropertyMoniker Name="BaseBatchStart/StartActivityGuid" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Email" MonikerAttributeName="" SerializeId="true" MonikerElementName="emailMoniker" ElementName="email" MonikerTypeName="EmailMoniker">
        <DomainClassMoniker Name="Email" />
      </XmlClassData>
      <XmlClassData TypeName="EmailShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="emailShapeMoniker" ElementName="emailShape" MonikerTypeName="EmailShapeMoniker">
        <ImageShapeMoniker Name="EmailShape" />
      </XmlClassData>
      <XmlClassData TypeName="MobileActivity" MonikerAttributeName="" SerializeId="true" MonikerElementName="mobileActivityMoniker" ElementName="mobileActivity" MonikerTypeName="MobileActivityMoniker">
        <DomainClassMoniker Name="MobileActivity" />
      </XmlClassData>
      <XmlClassData TypeName="MobileShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="mobileShapeMoniker" ElementName="mobileShape" MonikerTypeName="MobileShapeMoniker">
        <ImageShapeMoniker Name="MobileShape" />
      </XmlClassData>
      <XmlClassData TypeName="HybridActivity" MonikerAttributeName="" SerializeId="true" MonikerElementName="hybridActivityMoniker" ElementName="hybridActivity" MonikerTypeName="HybridActivityMoniker">
        <DomainClassMoniker Name="HybridActivity" />
      </XmlClassData>
      <XmlClassData TypeName="HybridShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="hybridShapeMoniker" ElementName="hybridShape" MonikerTypeName="HybridShapeMoniker">
        <ImageShapeMoniker Name="HybridShape" />
      </XmlClassData>
      <XmlClassData TypeName="UserActivity" MonikerAttributeName="" SerializeId="true" MonikerElementName="userActivityMoniker" ElementName="userActivity" MonikerTypeName="UserActivityMoniker">
        <DomainClassMoniker Name="UserActivity" />
        <ElementData>
          <XmlPropertyData XmlName="onlyVisibleAtLocation">
            <DomainPropertyMoniker Name="UserActivity/OnlyVisibleAtLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="locationRadius">
            <DomainPropertyMoniker Name="UserActivity/LocationRadius" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="UserActivityShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="userActivityShapeMoniker" ElementName="userActivityShape" MonikerTypeName="UserActivityShapeMoniker">
        <ImageShapeMoniker Name="UserActivityShape" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="CloudCoreArchitectSubProcessExplorerBehavior" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="FlowBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Flow" />
        <SourceDirectives>
          <RolePlayerConnectDirective UsesRoleSpecificCustomAccept="true">
            <AcceptingClass>
              <DomainClassMoniker Name="WorkflowRule" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="WorkflowRule" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
          <RolePlayerConnectDirective UsesRoleSpecificCustomAccept="true">
            <AcceptingClass>
              <DomainClassMoniker Name="Activity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="FlowMinimal" />
        <SourceDirectives>
          <RolePlayerConnectDirective UsesRoleSpecificCustomAccept="true">
            <AcceptingClass>
              <DomainClassMoniker Name="Activity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective UsesRoleSpecificCustomAccept="true">
            <AcceptingClass>
              <DomainClassMoniker Name="Activity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="FlowBaseBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="FlowBase" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Activity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Activity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="5b4bbe03-559a-4d76-abd5-8391818aa229" Description="Description for Architect.SubProcessDiagram" Name="SubProcessDiagram" DisplayName="SubProcess Designer" Namespace="Architect" GeneratesDoubleDerived="true">
    <Class>
      <DomainClassMoniker Name="SubProcess" />
    </Class>
    <ShapeMaps>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="WorkflowRule" />
        <ImageShapeMoniker Name="WorkflowRuleShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="DatabaseEvent" />
        <ImageShapeMoniker Name="SQLEventShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="CloudcoreUser" />
        <ImageShapeMoniker Name="PageShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="Stop" />
        <ImageShapeMoniker Name="StopShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="DatabasePark" />
        <ImageShapeMoniker Name="SQLParkShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Activity" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="BaseActivityShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="ToProcessConnector" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ToProcessConnectorShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="ToProcessConnector/ToProcessConnectorName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="ToProcessConnectorShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="FromProcessConnector" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="FromProcessConnectorShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="FromProcessConnector/FromProcessConnectorName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="FromProcessConnectorShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="CloudCustom" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <ImageShapeMoniker Name="CSharpEventShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="PostageApp" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <ImageShapeMoniker Name="PostageAppShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="Clickatell" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <ImageShapeMoniker Name="ClickatellShape" />
      </ShapeMap>
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="DatabaseCosting" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <ImageShapeMoniker Name="SQLCostingShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CloudCosting" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="BatchWaitShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="CSharpCostingShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CloudBatchWait" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="BatchWaitShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="BatchWaitShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CloudBatchStart" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="BatchWaitShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="CSharpBatchStartShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="DatabaseBatchStart" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="BatchWaitShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="SQLBatchStartShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CloudPark" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="CSharpParkShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Corticon" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="CorticonShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Start" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <IconDecoratorMoniker Name="StartableShape/IsStartableIconDecorator" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="Start/IsStartable" />
          </VisibilityPropertyPath>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="StartableShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="StartableShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="CustomUser" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="CustomUserShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="DatabaseBatchWait" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="DatabaseBatchWaitShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Activity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="DatabaseBatchWaitShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Email" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="EmailShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="MobileActivity" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="MobileShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="HybridActivity" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="HybridShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="UserActivity" />
        <ParentElementPath>
          <DomainPath>SubProcessHasActivities.SubProcess/!SubProcess</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <IconDecoratorMoniker Name="UserActivityShape/OnlyVisibleAtLocation" />
          <VisibilityPropertyPath>
            <DomainPropertyMoniker Name="UserActivity/OnlyVisibleAtLocation" />
          </VisibilityPropertyPath>
        </DecoratorMap>
        <ImageShapeMoniker Name="UserActivityShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="FlowConnector" />
        <DomainRelationshipMoniker Name="Flow" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="FlowConnector/OutcomeDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Flow/Outcome" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="FlowMinimalConnector" />
        <DomainRelationshipMoniker Name="FlowMinimal" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="subprocess" EditorGuid="6a850ae9-3487-4c6b-92a0-fbae153565fb" usesStickyToolboxItems="true">
    <RootClass>
      <DomainClassMoniker Name="SubProcess" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="CloudCoreArchitectSubProcessSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Database Activities">
      <Notes>Toolbox items for Architect SQL Activities</Notes>
      <ElementTool Name="SQLEvent" ToolboxIcon="Resources\ToolBox\EventTool.bmp" Caption="Database Custom Activity" Tooltip="Create Process Event" HelpKeyword="SQLEvent">
        <DomainClassMoniker Name="DatabaseEvent" />
      </ElementTool>
      <ElementTool Name="SQLCosting" ToolboxIcon="Resources\ToolBox\CostDBTool.bmp" Caption="Database Costing" Tooltip="SQLCosting" HelpKeyword="SQLCosting">
        <DomainClassMoniker Name="DatabaseCosting" />
      </ElementTool>
      <ElementTool Name="SQLBatchStart" ToolboxIcon="Resources\ToolBox\BatchStartTool.bmp" Caption="Database Batch Start" Tooltip="Batch DB Start" HelpKeyword="SQLBatchStart">
        <DomainClassMoniker Name="DatabaseBatchStart" />
      </ElementTool>
      <ElementTool Name="SQLParked" ToolboxIcon="Resources\ToolBox\DatabaseParkedTool.BMP" Caption="Database Parked Activity" Tooltip="SQLParked" HelpKeyword="SQLParked">
        <DomainClassMoniker Name="DatabasePark" />
      </ElementTool>
      <ElementTool Name="SQLBatchWait" ToolboxIcon="Resources\ToolBox\BatchWaitTool.bmp" Caption="Database Batch Wait Activity" Tooltip="SQLBatch Wait" HelpKeyword="SQLBatchWait">
        <DomainClassMoniker Name="DatabaseBatchWait" />
      </ElementTool>
    </ToolboxTab>
    <ToolboxTab TabText="Cloud Activities">
      <Notes>Toolbox items for Architect C# Activities</Notes>
      <ElementTool Name="Clickaltell" ToolboxIcon="Resources\ToolBox\Clickatell.bmp" Caption="Clickatell Activity" Tooltip="Clickaltell" HelpKeyword="Clickaltell">
        <DomainClassMoniker Name="Clickatell" />
      </ElementTool>
      <ElementTool Name="PostageApp" ToolboxIcon="Resources\ToolBox\PostageApp.bmp" Caption="PostageApp Activity" Tooltip="PostageApp" HelpKeyword="PostageApp">
        <DomainClassMoniker Name="PostageApp" />
      </ElementTool>
      <ElementTool Name="CSharpEvent" ToolboxIcon="Resources\ToolBox\CustomTool.bmp" Caption="Cloud Custom Activity" Tooltip="CSharp Event" HelpKeyword="CSharpEvent">
        <DomainClassMoniker Name="CloudCustom" />
      </ElementTool>
      <ElementTool Name="CSharpCosting" ToolboxIcon="Resources\ToolBox\CostClassTool.bmp" Caption="Cloud Costing" Tooltip="Create Process Costing Class" HelpKeyword="Costing">
        <DomainClassMoniker Name="CloudCosting" />
      </ElementTool>
      <ElementTool Name="CSharpBatchStart" ToolboxIcon="Resources\ToolBox\BatchStartTool.bmp" Caption="Cloud Batch Start" Tooltip="CSharp Batch Start" HelpKeyword="CSharpBatchStart">
        <DomainClassMoniker Name="CloudBatchStart" />
      </ElementTool>
      <ElementTool Name="CSharpParked" ToolboxIcon="Resources\ToolBox\CloudParkedTool.BMP" Caption="Cloud Parked Activity" Tooltip="CSharp Parked" HelpKeyword="CSharpParked">
        <DomainClassMoniker Name="CloudPark" />
      </ElementTool>
      <ElementTool Name="Corticon" ToolboxIcon="Resources\ToolBox\CorticonTool.bmp" Caption="Corticon Business Rule" Tooltip="Connect to your Corticon server." HelpKeyword="Corticon">
        <DomainClassMoniker Name="Corticon" />
      </ElementTool>
      <ElementTool Name="BatchWait" ToolboxIcon="Resources\ToolBox\BatchWaitTool.bmp" Caption="Cloud Batch Wait" Tooltip="Batch Wait" HelpKeyword="BatchWait">
        <DomainClassMoniker Name="CloudBatchWait" />
      </ElementTool>
      <ElementTool Name="Email" ToolboxIcon="Resources\ToolBox\EmailTool.bmp" Caption="Email" Tooltip="Email" HelpKeyword="Email">
        <DomainClassMoniker Name="Email" />
      </ElementTool>
    </ToolboxTab>
    <ToolboxTab TabText="Process Control">
      <Notes>Toolbox items for Architect Workflow</Notes>
      <ConnectionTool Name="Flow" ToolboxIcon="Resources\ToolBox\FlowTool.bmp" Caption="Flow" Tooltip="Flow" HelpKeyword="Flow" SourceCursorIcon="Resources\ConnectorSourceSearch.cur" TargetCursorIcon="Resources\ConnectorTargetSearch.cur">
        <ConnectionBuilderMoniker Name="CloudCoreArchitectSubProcess/FlowBuilder" />
      </ConnectionTool>
      <ElementTool Name="Stop" ToolboxIcon="Resources\ToolBox\StopTool.bmp" Caption="Process Stop/End" Tooltip="Stop" HelpKeyword="Stop">
        <DomainClassMoniker Name="Stop" />
      </ElementTool>
      <ElementTool Name="SubProcessConnector" ToolboxIcon="Resources\ToolBox\SubProcessTool.bmp" Caption="Sub Process Out" Tooltip="Sub Process Connector" HelpKeyword="SubProcess">
        <DomainClassMoniker Name="ToProcessConnector" />
      </ElementTool>
      <ElementTool Name="WorkflowRule" ToolboxIcon="Resources\ToolBox\RuleTool.bmp" Caption="Workflow Rule" Tooltip="Workflow Rule" HelpKeyword="WorkflowRule">
        <DomainClassMoniker Name="WorkflowRule" />
      </ElementTool>
    </ToolboxTab>
    <ToolboxTab TabText="User Activities">
      <ElementTool Name="CloudcoreUserActivity" ToolboxIcon="Resources\ToolBox\PageTool.bmp" Caption="Cloudcore User Activity" Tooltip="Cloudcore User Activity" HelpKeyword="CloudcoreUserActivity">
        <DomainClassMoniker Name="CloudcoreUser" />
      </ElementTool>
      <ElementTool Name="CustomUserActivity" ToolboxIcon="Resources\ToolBox\CustomUserActivity.BMP" Caption="Custom User Activity" Tooltip="Custom User Activity" HelpKeyword="CustomUserActivity">
        <DomainClassMoniker Name="CustomUser" />
      </ElementTool>
      <ElementTool Name="MobileUserActivity" ToolboxIcon="Resources\ToolBox\mobile-16px.BMP" Caption="MobileUserActivity" Tooltip="Mobile User Activity" HelpKeyword="MobileUserActivity">
        <DomainClassMoniker Name="MobileActivity" />
      </ElementTool>
      <ElementTool Name="HybridUserActivity" ToolboxIcon="Resources\ToolBox\mobile-16px.BMP" Caption="HybridUserActivity" Tooltip="Hybrid User Activity" HelpKeyword="HybridUserActivity">
        <DomainClassMoniker Name="HybridActivity" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesCustom="true" UsesLoad="false" />
    <DiagramMoniker Name="SubProcessDiagram" />
  </Designer>
</Dsl>