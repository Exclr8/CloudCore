﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace Architect
{
	/// <summary>
	/// ConnectionBuilder class to provide logic for constructing connections between elements.
	/// </summary>
	public static partial class FlowBuilder
	{
		#region Accept Connection Methods
		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the source of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the source of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptSource(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::Architect.WorkflowRule)
			{ 
				// Add a custom method to your code with the following signature:
				// private static bool CanAcceptWorkflowRuleAsSource(WorkflowRule candidate)
				// {
				// }
				return CanAcceptWorkflowRuleAsSource((global::Architect.WorkflowRule)candidate);
			}
			else if (candidate is global::Architect.Activity)
			{ 
				// Add a custom method to your code with the following signature:
				// private static bool CanAcceptActivityAsSource(Activity candidate)
				// {
				// }
				return CanAcceptActivityAsSource((global::Architect.Activity)candidate);
			}
			else
				return false;
		}

		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the target of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the target of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptTarget(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::Architect.WorkflowRule)
			{ 
				return true;
			}
			else if (candidate is global::Architect.Activity)
			{ 
				// Add a custom method to your code with the following signature:
				// private static bool CanAcceptActivityAsTarget(Activity candidate)
				// {
				// }
				return CanAcceptActivityAsTarget((global::Architect.Activity)candidate);
			}
			else if (candidate is global::Architect.Activity)
			{ 
				// Add a custom method to your code with the following signature:
				// private static bool CanAcceptActivityAsTarget(Activity candidate)
				// {
				// }
				return CanAcceptActivityAsTarget((global::Architect.Activity)candidate);
			}
			else
				return false;
		}
		
		/// <summary>
		/// Test whether a given pair of model elements are acceptable to this ConnectionBuilder as the source and target of a connection
		/// </summary>
		/// <param name="candidateSource">The model element to test as a source</param>
		/// <param name="candidateTarget">The model element to test as a target</param>
		/// <returns>Whether the elements can be used as the source and target of a connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static bool CanAcceptSourceAndTarget(DslModeling::ModelElement candidateSource, DslModeling::ModelElement candidateTarget)
		{
			// Accepts null, null; source, null; source, target but NOT null, target
			if (candidateSource == null)
			{
				if (candidateTarget != null)
				{
					throw new global::System.ArgumentNullException("candidateSource");
				}
				else // Both null
				{
					return false;
				}
			}
			bool acceptSource = CanAcceptSource(candidateSource);
			// If the source wasn't accepted then there's no point checking targets.
			// If there is no target then the source controls the accept.
			if (!acceptSource || candidateTarget == null)
			{
				return acceptSource;
			}
			else // Check combinations
			{
				if (candidateSource is global::Architect.WorkflowRule)
				{
					if (candidateTarget is global::Architect.WorkflowRule)
					{
						global::Architect.WorkflowRule sourceWorkflowRule = (global::Architect.WorkflowRule)candidateSource;
						global::Architect.WorkflowRule targetWorkflowRule = (global::Architect.WorkflowRule)candidateTarget;
						// Add a custom method to your code with the following signature:
						// private static bool CanAcceptWorkflowRuleAndWorkflowRuleAsSourceAndTarget(WorkflowRule sourceWorkflowRule, WorkflowRule targetWorkflowRule)
						// {
						// }
						if(!CanAcceptWorkflowRuleAndWorkflowRuleAsSourceAndTarget(sourceWorkflowRule, targetWorkflowRule)) return false;
						return true;
					}
					else if (candidateTarget is global::Architect.Activity)
					{
						global::Architect.WorkflowRule sourceWorkflowRule = (global::Architect.WorkflowRule)candidateSource;
						global::Architect.Activity targetActivity = (global::Architect.Activity)candidateTarget;
						// Add a custom method to your code with the following signature:
						// private static bool CanAcceptWorkflowRuleAndActivityAsSourceAndTarget(WorkflowRule sourceWorkflowRule, Activity targetActivity)
						// {
						// }
						if(!CanAcceptWorkflowRuleAndActivityAsSourceAndTarget(sourceWorkflowRule, targetActivity)) return false;
						return true;
					}
				}
				if (candidateSource is global::Architect.Activity)
				{
					if (candidateTarget is global::Architect.Activity)
					{
						global::Architect.Activity sourceActivity = (global::Architect.Activity)candidateSource;
						global::Architect.Activity targetActivity = (global::Architect.Activity)candidateTarget;
						// Add a custom method to your code with the following signature:
						// private static bool CanAcceptActivityAndActivityAsSourceAndTarget(Activity sourceActivity, Activity targetActivity)
						// {
						// }
						if(!CanAcceptActivityAndActivityAsSourceAndTarget(sourceActivity, targetActivity)) return false;
						if(targetActivity == null || sourceActivity == null || global::Architect.FlowMinimal.GetLinks(sourceActivity, targetActivity).Count > 0) return false;
						return true;
					}
				}
				
			}
			return false;
		}
		#endregion

		#region Connection Methods
		/// <summary>
		/// Make a connection between the given pair of source and target elements
		/// </summary>
		/// <param name="source">The model element to use as the source of the connection</param>
		/// <param name="target">The model element to use as the target of the connection</param>
		/// <returns>A link representing the created connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static DslModeling::ElementLink Connect(DslModeling::ModelElement source, DslModeling::ModelElement target)
		{
			if (source == null)
			{
				throw new global::System.ArgumentNullException("source");
			}
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			
			if (CanAcceptSourceAndTarget(source, target))
			{
				if (source is global::Architect.WorkflowRule)
				{
					if (target is global::Architect.WorkflowRule)
					{
						global::Architect.WorkflowRule sourceAccepted = (global::Architect.WorkflowRule)source;
						global::Architect.WorkflowRule targetAccepted = (global::Architect.WorkflowRule)target;
						DslModeling::ElementLink result = new global::Architect.Flow(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
					else if (target is global::Architect.Activity)
					{
						global::Architect.WorkflowRule sourceAccepted = (global::Architect.WorkflowRule)source;
						global::Architect.Activity targetAccepted = (global::Architect.Activity)target;
						DslModeling::ElementLink result = new global::Architect.Flow(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				if (source is global::Architect.Activity)
				{
					if (target is global::Architect.Activity)
					{
						global::Architect.Activity sourceAccepted = (global::Architect.Activity)source;
						global::Architect.Activity targetAccepted = (global::Architect.Activity)target;
						DslModeling::ElementLink result = new global::Architect.FlowMinimal(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				
			}
			global::System.Diagnostics.Debug.Fail("Having agreed that the connection can be accepted we should never fail to make one.");
			throw new global::System.InvalidOperationException();
		}
		#endregion
 	}
	/// <summary>
	/// ConnectionBuilder class to provide logic for constructing connections between elements.
	/// </summary>
	public static partial class FlowBaseBuilder
	{
		#region Accept Connection Methods
		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the source of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the source of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptSource(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::Architect.Activity)
			{ 
				return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the target of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the target of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptTarget(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::Architect.Activity)
			{ 
				return true;
			}
			else
				return false;
		}
		
		/// <summary>
		/// Test whether a given pair of model elements are acceptable to this ConnectionBuilder as the source and target of a connection
		/// </summary>
		/// <param name="candidateSource">The model element to test as a source</param>
		/// <param name="candidateTarget">The model element to test as a target</param>
		/// <returns>Whether the elements can be used as the source and target of a connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static bool CanAcceptSourceAndTarget(DslModeling::ModelElement candidateSource, DslModeling::ModelElement candidateTarget)
		{
			// Accepts null, null; source, null; source, target but NOT null, target
			if (candidateSource == null)
			{
				if (candidateTarget != null)
				{
					throw new global::System.ArgumentNullException("candidateSource");
				}
				else // Both null
				{
					return false;
				}
			}
			bool acceptSource = CanAcceptSource(candidateSource);
			// If the source wasn't accepted then there's no point checking targets.
			// If there is no target then the source controls the accept.
			if (!acceptSource || candidateTarget == null)
			{
				return acceptSource;
			}
			else // Check combinations
			{
				if (candidateSource is global::Architect.Activity)
				{
					if (candidateTarget is global::Architect.Activity)
					{
						return true;
					}
				}
				
			}
			return false;
		}
		#endregion

		#region Connection Methods
		/// <summary>
		/// Make a connection between the given pair of source and target elements
		/// </summary>
		/// <param name="source">The model element to use as the source of the connection</param>
		/// <param name="target">The model element to use as the target of the connection</param>
		/// <returns>A link representing the created connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static DslModeling::ElementLink Connect(DslModeling::ModelElement source, DslModeling::ModelElement target)
		{
			if (source == null)
			{
				throw new global::System.ArgumentNullException("source");
			}
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			
			if (CanAcceptSourceAndTarget(source, target))
			{
				if (source is global::Architect.Activity)
				{
					if (target is global::Architect.Activity)
					{
						global::Architect.Activity sourceAccepted = (global::Architect.Activity)source;
						global::Architect.Activity targetAccepted = (global::Architect.Activity)target;
						DslModeling::ElementLink result = new global::Architect.FlowBase(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				
			}
			global::System.Diagnostics.Debug.Fail("Having agreed that the connection can be accepted we should never fail to make one.");
			throw new global::System.InvalidOperationException();
		}
		#endregion
 	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SQLEventCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SQLEventCreateAction for the given Diagram.
		/// </summary>
		public SQLEventCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SQLCostingCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SQLCostingCreateAction for the given Diagram.
		/// </summary>
		public SQLCostingCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SQLBatchStartCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SQLBatchStartCreateAction for the given Diagram.
		/// </summary>
		public SQLBatchStartCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SQLParkedCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SQLParkedCreateAction for the given Diagram.
		/// </summary>
		public SQLParkedCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SQLBatchWaitCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SQLBatchWaitCreateAction for the given Diagram.
		/// </summary>
		public SQLBatchWaitCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class ClickaltellCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new ClickaltellCreateAction for the given Diagram.
		/// </summary>
		public ClickaltellCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class PostageAppCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new PostageAppCreateAction for the given Diagram.
		/// </summary>
		public PostageAppCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CSharpEventCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CSharpEventCreateAction for the given Diagram.
		/// </summary>
		public CSharpEventCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CSharpCostingCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CSharpCostingCreateAction for the given Diagram.
		/// </summary>
		public CSharpCostingCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CSharpBatchStartCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CSharpBatchStartCreateAction for the given Diagram.
		/// </summary>
		public CSharpBatchStartCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CSharpParkedCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CSharpParkedCreateAction for the given Diagram.
		/// </summary>
		public CSharpParkedCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CorticonCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CorticonCreateAction for the given Diagram.
		/// </summary>
		public CorticonCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class BatchWaitCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new BatchWaitCreateAction for the given Diagram.
		/// </summary>
		public BatchWaitCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class EmailCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new EmailCreateAction for the given Diagram.
		/// </summary>
		public EmailCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}
 	
 	/// <summary>
	/// Handles interaction between the ConnectionBuilder and the corresponding ConnectionTool.
	/// </summary>
	internal partial class FlowConnectAction : DslDiagrams::ConnectAction
	{
		private DslDiagrams::ConnectionType[] connectionTypes;
		private global::System.Windows.Forms.Cursor sourceCursor;
		private global::System.Windows.Forms.Cursor targetCursor;
		
		/// <summary>
		/// Constructs a new FlowConnectAction for the given Diagram.
		/// </summary>
		public FlowConnectAction(DslDiagrams::Diagram diagram): base(diagram, true) 
		{
			global::System.Resources.ResourceManager resourceManager = global::Architect.CloudCoreArchitectSubProcessDomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;

			byte[] sourceCursorBytes = (byte[])resourceManager.GetObject("FlowSourceCursor", resourceCulture);
			using(global::System.IO.MemoryStream sourceCursorStream = new global::System.IO.MemoryStream(sourceCursorBytes))
			{ 
				this.sourceCursor = new global::System.Windows.Forms.Cursor(sourceCursorStream);
			}
			byte[] targetCursorBytes = (byte[])resourceManager.GetObject("FlowTargetCursor", resourceCulture);
			using(global::System.IO.MemoryStream targetCursorStream = new global::System.IO.MemoryStream(targetCursorBytes))
			{ 
				this.targetCursor = new global::System.Windows.Forms.Cursor(targetCursorStream);
			}
		}
		
		/// <summary>
		/// Gets the cursor corresponding to the given mouse position.
		/// </summary>
		/// <remarks>
		/// Changes the cursor to Cursors.No before the first mouse click if the source shape is not valid.
		/// </remarks>
		public override global::System.Windows.Forms.Cursor GetCursor(global::System.Windows.Forms.Cursor currentCursor, DslDiagrams::DiagramClientView diagramClientView, DslDiagrams::PointD mousePosition)
		{
			if (this.MouseDownHitShape == null && currentCursor != global::System.Windows.Forms.Cursors.No)
			{
				DslDiagrams::DiagramHitTestInfo hitTestInfo = new DslDiagrams::DiagramHitTestInfo(diagramClientView);
				this.Diagram.DoHitTest(mousePosition, hitTestInfo);
				DslDiagrams::ShapeElement shape = hitTestInfo.HitDiagramItem.Shape;

				DslDiagrams::ConnectionType connectionType = GetConnectionTypes(shape, null)[0];
				string warningString = string.Empty;
				if (!connectionType.CanCreateConnection(shape, null, ref warningString))
				{
					return global::System.Windows.Forms.Cursors.No;
				}
			}
			return base.GetCursor(currentCursor, diagramClientView, mousePosition);
		}
		
		/// <summary>
		/// Associates custom source and target cursors with the connect action.
		/// </summary>
		protected override global::System.Windows.Forms.Cursor GetCursorFromCursorType(DslDiagrams::ConnectActionCursor connectActionCursor)
		{
			if(connectActionCursor == DslDiagrams::ConnectActionCursor.Searching)
			{
				return this.sourceCursor;
			}
			if(connectActionCursor == DslDiagrams::ConnectActionCursor.Allowed)
			{
				return this.targetCursor;
			}
			return base.GetCursorFromCursorType(connectActionCursor);
		}
		
		/// <summary>
		/// Disposes custom cursor resources.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					if(this.sourceCursor != null)
					{
						this.sourceCursor.Dispose();
						this.sourceCursor = null;
					}
					if(this.targetCursor != null)
					{
						this.targetCursor.Dispose();
						this.targetCursor = null;
					}
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		/// <summary>
		/// Returns the FlowConnectionType associated with this action.
		/// </summary>
		protected override DslDiagrams::ConnectionType[] GetConnectionTypes(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement)
		{
			if(this.connectionTypes == null)
			{
				this.connectionTypes = new DslDiagrams::ConnectionType[] { new FlowConnectionType() };
			}
			
			return this.connectionTypes;
		}
		
		private partial class FlowConnectionTypeBase : DslDiagrams::ConnectionType
		{
			/// <summary>
			/// Constructs a new the FlowConnectionType with the given ConnectionBuilder.
			/// </summary>
			protected FlowConnectionTypeBase() : base() {}
			
			private static DslDiagrams::ShapeElement RemovePassThroughShapes(DslDiagrams::ShapeElement shape)
			{
				if (shape is DslDiagrams::Compartment)
				{
					return shape.ParentShape;
				}
				DslDiagrams::SwimlaneShape swimlane = shape as DslDiagrams::SwimlaneShape;
				if (swimlane != null && swimlane.ForwardDragDropToParent)
				{
					return shape.ParentShape;
				}
				return shape;
			}
						
			/// <summary>
			/// Called by the base ConnectAction class to determine if the given shapes can be connected.
			/// </summary>
			/// <remarks>
			/// This implementation delegates calls to the ConnectionBuilder FlowBuilder.
			/// </remarks>
			public override bool CanCreateConnection(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement, ref string connectionWarning)
			{
				bool canConnect = true;
				
				if(sourceShapeElement == null) throw new global::System.ArgumentNullException("sourceShapeElement");
				sourceShapeElement = RemovePassThroughShapes(sourceShapeElement);
				DslModeling::ModelElement sourceElement = sourceShapeElement.ModelElement;
				if(sourceElement == null) sourceElement = sourceShapeElement;
				
				DslModeling::ModelElement targetElement = null;
				if (targetShapeElement != null)
				{
					targetShapeElement = RemovePassThroughShapes(targetShapeElement);
					targetElement = targetShapeElement.ModelElement;
					if(targetElement == null) targetElement = targetShapeElement;
			
				}

				// base.CanCreateConnection must be called to check whether existing Locks prevent this link from getting created.	
				canConnect = base.CanCreateConnection(sourceShapeElement, targetShapeElement, ref connectionWarning);
				if (canConnect)
				{				
					if(targetShapeElement == null)
					{
						return FlowBuilder.CanAcceptSource(sourceElement);
					}
					else
					{				
						return FlowBuilder.CanAcceptSourceAndTarget(sourceElement, targetElement);
					}
				}
				else
				{
					//return false
					return canConnect;
				}
			}
						
			/// <summary>
			/// Called by the base ConnectAction class to ask whether the given source and target are valid.
			/// </summary>
			/// <remarks>
			/// Always return true here, to give CanCreateConnection a chance to decide.
			/// </remarks>
			public override bool IsValidSourceAndTarget(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement)
			{
				return true;
			}
			
			/// <summary>
			/// Called by the base ConnectAction class to create the underlying relationship.
			/// </summary>
			/// <remarks>
			/// This implementation delegates calls to the ConnectionBuilder FlowBuilder.
			/// </remarks>
			public override void CreateConnection(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement, DslDiagrams::PaintFeedbackArgs paintFeedbackArgs)
			{
				if(sourceShapeElement == null) throw new global::System.ArgumentNullException("sourceShapeElement");
				if(targetShapeElement == null) throw new global::System.ArgumentNullException("targetShapeElement");
				
				sourceShapeElement = RemovePassThroughShapes(sourceShapeElement);
				targetShapeElement = RemovePassThroughShapes(targetShapeElement);
				
				DslModeling::ModelElement sourceElement = sourceShapeElement.ModelElement;
				if(sourceElement == null) sourceElement = sourceShapeElement;
				DslModeling::ModelElement targetElement = targetShapeElement.ModelElement;
				if(targetElement == null) targetElement = targetShapeElement;
				FlowBuilder.Connect(sourceElement, targetElement);
			}
		}
		
		private partial class FlowConnectionType : FlowConnectionTypeBase
		{
			/// <summary>
			/// Constructs a new the FlowConnectionType with the given ConnectionBuilder.
			/// </summary>
			public FlowConnectionType() : base() {}
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class StopCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new StopCreateAction for the given Diagram.
		/// </summary>
		public StopCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SubProcessConnectorCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SubProcessConnectorCreateAction for the given Diagram.
		/// </summary>
		public SubProcessConnectorCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class WorkflowRuleCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new WorkflowRuleCreateAction for the given Diagram.
		/// </summary>
		public WorkflowRuleCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CloudcoreUserActivityCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CloudcoreUserActivityCreateAction for the given Diagram.
		/// </summary>
		public CloudcoreUserActivityCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class CustomUserActivityCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new CustomUserActivityCreateAction for the given Diagram.
		/// </summary>
		public CustomUserActivityCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class MobileUserActivityCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new MobileUserActivityCreateAction for the given Diagram.
		/// </summary>
		public MobileUserActivityCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class HybridUserActivityCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new HybridUserActivityCreateAction for the given Diagram.
		/// </summary>
		public HybridUserActivityCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}
}

