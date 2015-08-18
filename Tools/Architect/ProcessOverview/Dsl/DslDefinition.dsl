<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="2fe2d54b-e4e0-481c-bf34-bc40133efaf7" Description="CloudCore architect process overview designer" Name="CloudCoreArchitectProcessOverview" DisplayName="CloudCore - Architect Process Overview Designer" Namespace="Architect.ProcessOverview" ProductName="CloudCore -  Architect Process Overview Designer" CompanyName="Framework One" PackageGuid="a82781ab-ef77-4e96-834c-3caea8e141c1" PackageNamespace="Architect.ProcessOverview" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="922e3637-cd44-4de1-9dc1-923199f315a5" Description="The root in which all other elements are embedded. Appears as a diagram." Name="Process" DisplayName="Process" Namespace="Architect.ProcessOverview">
      <Properties>
        <DomainProperty Id="04dfb678-f4ae-4c67-857d-835a0f8733f0" Description="Description for Architect.ProcessOverview.Process.Process Name" Name="ProcessName" DisplayName="Process Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8ecb37d8-319a-406a-a166-2ff359d1a40d" Description="Description for Architect.ProcessOverview.Process.Visio Id" Name="VisioId" DisplayName="Visio Id" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="SubProcessElement" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ProcessHasSubProcess.BTSubProcess</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="7964ac48-bc42-4e2c-89ff-1306fe0247d2" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="SubProcessElement" DisplayName="Sub Process Element" Namespace="Architect.ProcessOverview">
      <Properties>
        <DomainProperty Id="391e3432-73eb-40ef-9b80-80972c952632" Description="Description for Architect.ProcessOverview.SubProcessElement.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e057da04-30ad-4ca1-8e46-284902b07f18" Description="Description for Architect.ProcessOverview.SubProcessElement.Sub Process Ref" Name="SubProcessRef" DisplayName="Sub Process Ref">
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
                <AttributeParameter Value="&quot;Choose a sub process file&quot;" />
                <AttributeParameter Value="&quot;SubProcess file|*.subprocess&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/Microsoft.VisualStudio.Modeling.Integration/ModelBusReference" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7a7c40c0-6cc2-414c-b1ab-bda67f69acc0" Description="Description for Architect.ProcessOverview.SubProcessElement.Visio Id" Name="VisioId" DisplayName="Visio Id">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="e96e4974-2a02-4c65-9f5e-1f15d14d8659" Description="Embedding relationship between the Model and Elements" Name="ProcessHasSubProcess" DisplayName="Process Has Sub Process" Namespace="Architect.ProcessOverview" IsEmbedding="true">
      <Source>
        <DomainRole Id="51db268d-b7b2-4323-94c7-e6ce9ee68491" Description="" Name="Process" DisplayName="Process" PropertyName="BTSubProcess" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="BTSub Process">
          <RolePlayer>
            <DomainClassMoniker Name="Process" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9aaa5aba-b92a-4c5e-a583-cd70309764e0" Description="" Name="Element" DisplayName="Element" PropertyName="Process" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Process">
          <RolePlayer>
            <DomainClassMoniker Name="SubProcessElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="13f33ea5-7b0c-44f6-b59e-2d2d7d16b29c" Description="Reference relationship between Elements." Name="SubProcessElementReferencesTargets" DisplayName="Sub Process Element References Targets" Namespace="Architect.ProcessOverview" AllowsDuplicates="true">
      <Source>
        <DomainRole Id="3b39e121-3a15-4054-99c6-fc2a2072e3de" Description="Description for Architect.ProcessOverview.ExampleRelationship.Target" Name="Source" DisplayName="Source" PropertyName="Targets" PropertyDisplayName="Targets">
          <RolePlayer>
            <DomainClassMoniker Name="SubProcessElement" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="334f3a23-87ee-419f-a077-9697a9bebbc5" Description="Description for Architect.ProcessOverview.ExampleRelationship.Source" Name="Target" DisplayName="Target" PropertyName="Sources" PropertyDisplayName="Sources">
          <RolePlayer>
            <DomainClassMoniker Name="SubProcessElement" />
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
    <ExternalType Name="ModelBusReference" Namespace="Microsoft.VisualStudio.Modeling.Integration" />
  </Types>
  <Shapes>
    <GeometryShape Id="4979ba50-dc80-4e77-ad7c-106ca30a3d10" Description="Shape used to represent ExampleElements on a Diagram." Name="SubProcessShape" DisplayName="Sub Process Shape" Namespace="Architect.ProcessOverview" FixedTooltipText="Sub Process Shape" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="8194daa8-9dd6-4bed-bc91-2126c3d40292" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="SubProcessConnector" DisplayName="Sub Process Connector" Namespace="Architect.ProcessOverview" FixedTooltipText="Sub Process Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
  </Connectors>
  <XmlSerializationBehavior Name="CloudCoreArchitectProcessOverviewSerializationBehavior" Namespace="Architect.ProcessOverview">
    <ClassData>
      <XmlClassData TypeName="Process" MonikerAttributeName="" SerializeId="true" MonikerElementName="processMoniker" ElementName="process" MonikerTypeName="ProcessMoniker">
        <DomainClassMoniker Name="Process" />
        <ElementData>
          <XmlRelationshipData RoleElementName="bTSubProcess">
            <DomainRelationshipMoniker Name="ProcessHasSubProcess" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="processName">
            <DomainPropertyMoniker Name="Process/ProcessName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visioId">
            <DomainPropertyMoniker Name="Process/VisioId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SubProcessElement" MonikerAttributeName="name" SerializeId="true" MonikerElementName="subProcessElementMoniker" ElementName="subProcessElement" MonikerTypeName="SubProcessElementMoniker">
        <DomainClassMoniker Name="SubProcessElement" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="SubProcessElement/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targets">
            <DomainRelationshipMoniker Name="SubProcessElementReferencesTargets" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="subProcessRef">
            <DomainPropertyMoniker Name="SubProcessElement/SubProcessRef" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visioId">
            <DomainPropertyMoniker Name="SubProcessElement/VisioId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ProcessHasSubProcess" MonikerAttributeName="" SerializeId="true" MonikerElementName="processHasSubProcessMoniker" ElementName="processHasSubProcess" MonikerTypeName="ProcessHasSubProcessMoniker">
        <DomainRelationshipMoniker Name="ProcessHasSubProcess" />
      </XmlClassData>
      <XmlClassData TypeName="SubProcessElementReferencesTargets" MonikerAttributeName="" SerializeId="true" MonikerElementName="subProcessElementReferencesTargetsMoniker" ElementName="subProcessElementReferencesTargets" MonikerTypeName="SubProcessElementReferencesTargetsMoniker">
        <DomainRelationshipMoniker Name="SubProcessElementReferencesTargets" />
      </XmlClassData>
      <XmlClassData TypeName="SubProcessShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="subProcessShapeMoniker" ElementName="subProcessShape" MonikerTypeName="SubProcessShapeMoniker">
        <GeometryShapeMoniker Name="SubProcessShape" />
      </XmlClassData>
      <XmlClassData TypeName="SubProcessConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="subProcessConnectorMoniker" ElementName="subProcessConnector" MonikerTypeName="SubProcessConnectorMoniker">
        <ConnectorMoniker Name="SubProcessConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ProcessOverviewDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="processOverviewDiagramMoniker" ElementName="processOverviewDiagram" MonikerTypeName="ProcessOverviewDiagramMoniker">
        <DiagramMoniker Name="ProcessOverviewDiagram" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ProcessOverviewExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="SubProcessElementReferencesTargetsBuilder">
      <Notes>Provides for the creation of an ExampleRelationship by pointing at two ExampleElements.</Notes>
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SubProcessElementReferencesTargets" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SubProcessElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SubProcessElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="8a7c8ad5-6456-4e63-8737-de29dd67ff11" Description="Description for Architect.ProcessOverview.ProcessOverviewDiagram" Name="ProcessOverviewDiagram" DisplayName="Process Overview Diagram" Namespace="Architect.ProcessOverview" GeneratesDoubleDerived="true">
    <Class>
      <DomainClassMoniker Name="Process" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="SubProcessElement" />
        <ParentElementPath>
          <DomainPath>ProcessHasSubProcess.Process/!Process</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="SubProcessShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SubProcessElement/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="SubProcessShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="SubProcessConnector" />
        <DomainRelationshipMoniker Name="SubProcessElementReferencesTargets" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="process" EditorGuid="c7dbb627-2704-4609-9b03-6ca2207dbcc2">
    <RootClass>
      <DomainClassMoniker Name="Process" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="CloudCoreArchitectProcessOverviewSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="ProcessOverview" />
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ProcessOverviewDiagram" />
  </Designer>
</Dsl>