<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="ff28ec1f-f310-45dd-856e-de127249ab8b" Description="Architect Scheduled Tasks" Name="ScheduledTasks" DisplayName="ScheduledTasks" Namespace="Architect.ScheduledTasks" ProductName="ScheduledTasks" CompanyName="Architect" PackageGuid="5a65e48f-af3b-49a1-930d-c3ba417cd25f" PackageNamespace="Architect.ScheduledTasks" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="39536a68-786f-43c4-a235-1c59234aa00c" Description="A group containing scheduled tasks" Name="Group" DisplayName="Group" Namespace="Architect.ScheduledTasks">
      <Properties>
        <DomainProperty Id="fc3d526c-9ab9-4bec-a2c4-e1d7ef6e8fbf" Description="Description for Architect.ScheduledTasks.Group.Group Name" Name="GroupName" DisplayName="Group Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="BaseScheduledTask" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>GroupHasScheduledTasks.Elements</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="d2b1d2d8-e972-49b0-bb4c-b81497c82631" Description="Scheduled Task base" Name="BaseScheduledTask" DisplayName="Base Scheduled Task" Namespace="Architect.ScheduledTasks">
      <Properties>
        <DomainProperty Id="f5b43d9e-22bd-43bb-a52c-7aed28276f3c" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4c434a15-f642-4aaa-85d5-a98e0aec6df5" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Interval Type" Name="IntervalType" DisplayName="Interval Type" DefaultValue="Hours">
          <Type>
            <DomainEnumerationMoniker Name="IntervalType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9e45b686-4478-4ebf-b0c2-198f8737374e" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Interval" Name="Interval" DisplayName="Interval" DefaultValue="1">
          <Type>
            <ExternalTypeMoniker Name="/System/Int32" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="34218f09-87a9-4758-aed8-235fbd155967" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Start Date" Name="StartDate" DisplayName="Start Date">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Architect.ScheduledTasks.Editors.CCDateTimeEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/DateTime" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1362b1a3-50d4-4059-bc7b-7ef4928b4d7e" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Type" Name="Type" DisplayName="Type" Kind="Calculated" SetterAccessModifier="Assembly" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TaskType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="833b1068-55f8-453d-9f68-0327767f63da" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Descriptive Interval" Name="DescriptiveInterval" DisplayName="Descriptive Interval" Kind="Calculated" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1f4da2cf-35a5-40b3-95fb-dc076c2e8c9e" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Start Date Only" Name="StartDateOnly" DisplayName="Start Date Only" Kind="Calculated" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9492a571-9af3-43be-b661-4c7fad692904" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Start Time Only" Name="StartTimeOnly" DisplayName="Start Time Only" Kind="Calculated" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ee62561a-3a54-4985-8224-59fc8806e954" Description="Description for Architect.ScheduledTasks.BaseScheduledTask.Type Display" Name="TypeDisplay" DisplayName="Type Display" Kind="Calculated" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="7096e275-4fff-4dea-ae48-40866115dbe3" Description="Description for Architect.ScheduledTasks.CSharpScheduledTask" Name="CSharpScheduledTask" DisplayName="CSharp Scheduled Task" Namespace="Architect.ScheduledTasks">
      <BaseClass>
        <DomainClassMoniker Name="BaseScheduledTask" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="e11d0752-d5f1-4e56-838b-ee430adda934" Description="Description for Architect.ScheduledTasks.SqlScheduledTask" Name="SqlScheduledTask" DisplayName="Sql Scheduled Task" Namespace="Architect.ScheduledTasks">
      <BaseClass>
        <DomainClassMoniker Name="BaseScheduledTask" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="11b948f4-6be3-4e5a-b694-4cc647550e70" Description="Embedding relationship between the Model and Elements" Name="GroupHasScheduledTasks" DisplayName="Group Has Scheduled Tasks" Namespace="Architect.ScheduledTasks" IsEmbedding="true">
      <Source>
        <DomainRole Id="748a0963-b58c-4398-9627-82a43a3f1a53" Description="" Name="Group" DisplayName="Group" PropertyName="Elements" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Elements">
          <RolePlayer>
            <DomainClassMoniker Name="Group" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f30e5160-dd16-4061-92cf-440cd2cc9674" Description="" Name="Element" DisplayName="Element" PropertyName="Group" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Group">
          <RolePlayer>
            <DomainClassMoniker Name="BaseScheduledTask" />
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
    <DomainEnumeration Name="IntervalType" Namespace="Architect.ScheduledTasks" Description="Description for Architect.ScheduledTasks.IntervalType">
      <Literals>
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Years" Name="Years" Value="0" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Months" Name="Months" Value="1" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Weeks" Name="Weeks" Value="2" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Days" Name="Days" Value="3" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Hours" Name="Hours" Value="4" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Minutes" Name="Minutes" Value="5" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.IntervalType.Seconds" Name="Seconds" Value="6" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="TaskType" Namespace="Architect.ScheduledTasks" Description="Description for Architect.ScheduledTasks.TaskType">
      <Literals>
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.TaskType.CSharp" Name="CSharp" Value="1" />
        <EnumerationLiteral Description="Description for Architect.ScheduledTasks.TaskType.SQL" Name="SQL" Value="0" />
      </Literals>
    </DomainEnumeration>
  </Types>
  <Shapes>
    <GeometryShape Id="f7d6820f-8548-469b-8d75-49971884da93" Description="Shape used to represent Scheduled Tasks on a Diagram." Name="ScheduledTaskShape" DisplayName="Scheduled Task Shape" Namespace="Architect.ScheduledTasks" FixedTooltipText="Scheduled Task Shape" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="1.7" InitialHeight="1.5" OutlineThickness="0.01" Geometry="RoundedRectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" FontStyle="Bold, Underline" FontSize="10" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerBottomRight" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="TypeDecorator" DisplayName="Type Decorator" DefaultText="TypeDecorator" FontStyle="Bold" FontSize="10" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0.3">
        <TextDecorator Name="DescribeIntervalDecorator" DisplayName="Describe Interval Decorator" DefaultText="DescribeIntervalDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0.45">
        <TextDecorator Name="StartDateOnlyDecorator" DisplayName="Start Date Only Decorator" DefaultText="StartDateOnlyDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0.6">
        <TextDecorator Name="StartTimeOnlyDecorator" DisplayName="Start Time Only Decorator" DefaultText="StartTimeOnlyDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <XmlSerializationBehavior Name="ScheduledTasksSerializationBehavior" Namespace="Architect.ScheduledTasks">
    <ClassData>
      <XmlClassData TypeName="Group" MonikerAttributeName="" SerializeId="true" MonikerElementName="groupMoniker" ElementName="group" MonikerTypeName="GroupMoniker">
        <DomainClassMoniker Name="Group" />
        <ElementData>
          <XmlRelationshipData RoleElementName="elements">
            <DomainRelationshipMoniker Name="GroupHasScheduledTasks" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="groupName">
            <DomainPropertyMoniker Name="Group/GroupName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="BaseScheduledTask" MonikerAttributeName="name" SerializeId="true" MonikerElementName="baseScheduledTaskMoniker" ElementName="baseScheduledTask" MonikerTypeName="BaseScheduledTaskMoniker">
        <DomainClassMoniker Name="BaseScheduledTask" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="BaseScheduledTask/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="intervalType">
            <DomainPropertyMoniker Name="BaseScheduledTask/IntervalType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="interval">
            <DomainPropertyMoniker Name="BaseScheduledTask/Interval" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="startDate">
            <DomainPropertyMoniker Name="BaseScheduledTask/StartDate" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type" Representation="Ignore">
            <DomainPropertyMoniker Name="BaseScheduledTask/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="descriptiveInterval" Representation="Ignore">
            <DomainPropertyMoniker Name="BaseScheduledTask/DescriptiveInterval" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="startDateOnly" Representation="Ignore">
            <DomainPropertyMoniker Name="BaseScheduledTask/StartDateOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="startTimeOnly" Representation="Ignore">
            <DomainPropertyMoniker Name="BaseScheduledTask/StartTimeOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="typeDisplay" Representation="Ignore">
            <DomainPropertyMoniker Name="BaseScheduledTask/TypeDisplay" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="GroupHasScheduledTasks" MonikerAttributeName="" SerializeId="true" MonikerElementName="groupHasScheduledTasksMoniker" ElementName="groupHasScheduledTasks" MonikerTypeName="GroupHasScheduledTasksMoniker">
        <DomainRelationshipMoniker Name="GroupHasScheduledTasks" />
      </XmlClassData>
      <XmlClassData TypeName="ScheduledTaskShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="scheduledTaskShapeMoniker" ElementName="scheduledTaskShape" MonikerTypeName="ScheduledTaskShapeMoniker">
        <GeometryShapeMoniker Name="ScheduledTaskShape" />
      </XmlClassData>
      <XmlClassData TypeName="ScheduledTasksDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="scheduledTasksDiagramMoniker" ElementName="scheduledTasksDiagram" MonikerTypeName="ScheduledTasksDiagramMoniker">
        <DiagramMoniker Name="ScheduledTasksDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="CSharpScheduledTask" MonikerAttributeName="" SerializeId="true" MonikerElementName="cSharpScheduledTaskMoniker" ElementName="cSharpScheduledTask" MonikerTypeName="CSharpScheduledTaskMoniker">
        <DomainClassMoniker Name="CSharpScheduledTask" />
      </XmlClassData>
      <XmlClassData TypeName="SqlScheduledTask" MonikerAttributeName="" SerializeId="true" MonikerElementName="sqlScheduledTaskMoniker" ElementName="sqlScheduledTask" MonikerTypeName="SqlScheduledTaskMoniker">
        <DomainClassMoniker Name="SqlScheduledTask" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ScheduledTasksExplorer" />
  <Diagram Id="ca248838-9c46-4656-8297-6da05bd8c17b" Description="Description for Architect.ScheduledTasks.ScheduledTasksDiagram" Name="ScheduledTasksDiagram" DisplayName="Minimal Language Diagram" Namespace="Architect.ScheduledTasks" GeneratesDoubleDerived="true">
    <Class>
      <DomainClassMoniker Name="Group" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="BaseScheduledTask" />
        <ParentElementPath>
          <DomainPath>GroupHasScheduledTasks.Group/!Group</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ScheduledTaskShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="BaseScheduledTask/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ScheduledTaskShape/TypeDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="BaseScheduledTask/TypeDisplay" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ScheduledTaskShape/DescribeIntervalDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="BaseScheduledTask/DescriptiveInterval" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ScheduledTaskShape/StartDateOnlyDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="BaseScheduledTask/StartDateOnly" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ScheduledTaskShape/StartTimeOnlyDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="BaseScheduledTask/StartTimeOnly" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="ScheduledTaskShape" />
      </ShapeMap>
    </ShapeMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="stask" EditorGuid="e18c1e7a-1349-4909-be19-0dff3fe665fe">
    <RootClass>
      <DomainClassMoniker Name="Group" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ScheduledTasksSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="ScheduledTasks">
      <ElementTool Name="CSharpScheduledTask" ToolboxIcon="Resources\CsharpTool.bmp" Caption="C# Scheduled Task" Tooltip="Create an C# Scheduled Task" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="CSharpScheduledTask" />
      </ElementTool>
      <ElementTool Name="SQLScheduledTask" ToolboxIcon="Resources\SQLTool.bmp" Caption="SQL Scheduled Task" Tooltip="Create an SQL Scheduled Task" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="SqlScheduledTask" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesLoad="true" />
    <DiagramMoniker Name="ScheduledTasksDiagram" />
  </Designer>
</Dsl>