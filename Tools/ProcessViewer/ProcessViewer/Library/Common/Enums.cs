using System;

namespace ProcessViewer.Library
{
    public enum DiagramType
    {
        Msagl,
        Visio
    }

    public enum ViewLevel
    {
        SubProcess,
        Activity
    }

    [Flags]
    public enum Options
    {
        None = 0,
        Colour = 1,
        Id = 2,
        Activity = 4,
        Cost = 8,
        Instance = 16
    }

    public enum DBVersion
    {
        Version1,
        Version2
    }

    public enum ShapeType
    {
        Custom_User_Activity,
        Cloudcore_User_Activity,
        Cloud_Batch_Start,
        Cloud_Batch_Wait,
        Cloud_Costing,
        Cloud_Custom_Activity,
        Cloud_Parked_Activity,
        Database_Batch_Start,
        Database_Batch_Wait,
        Database_Costing,
        Database_Custom_Activity,
        Database_Parked_Activity,
        Corticon_Business_Rule,
        Email_Activity,
        SMS_Activity,
        Flow_Rule,
        Process_Stop,
        SubProcess,
        Flow_Connector,



        Page,
        Event, 
        Rule,
        Trigger,
        StartPage,
        StartableTask, 
        DecisionTask,
        NormalTask,
        Finish
    }
}
