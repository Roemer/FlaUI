﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IWindowPattern : IPattern
    {
        IWindowPatternProperties Properties { get; }
        IWindowPatternEvents Events { get; }

        AutomationProperty<bool> CanMaximize { get; }
        AutomationProperty<bool> CanMinimize { get; }
        AutomationProperty<bool> IsModal { get; }
        AutomationProperty<bool> IsTopmost { get; }
        AutomationProperty<WindowInteractionState> WindowInteractionState { get; }
        AutomationProperty<WindowVisualState> WindowVisualState { get; }

        void Close();
        void SetWindowVisualState(WindowVisualState state);
        bool WaitForInputIdle(int milliseconds);
    }

    public interface IWindowPatternProperties
    {
        PropertyId CanMaximizeProperty { get; }
        PropertyId CanMinimizeProperty { get; }
        PropertyId IsModalProperty { get; }
        PropertyId IsTopmostProperty { get; }
        PropertyId WindowInteractionStateProperty { get; }
        PropertyId WindowVisualStateProperty { get; }
    }

    public interface IWindowPatternEvents
    {
        EventId WindowClosedEvent { get; }
        EventId WindowOpenedEvent { get; }
    }

    public abstract class WindowPatternBase<TNativePattern> : PatternBase<TNativePattern>, IWindowPattern
    {
        protected WindowPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            CanMaximize = new AutomationProperty<bool>(() => Properties.CanMaximizeProperty, BasicAutomationElement);
            CanMinimize = new AutomationProperty<bool>(() => Properties.CanMinimizeProperty, BasicAutomationElement);
            IsModal = new AutomationProperty<bool>(() => Properties.IsModalProperty, BasicAutomationElement);
            IsTopmost = new AutomationProperty<bool>(() => Properties.IsTopmostProperty, BasicAutomationElement);
            WindowInteractionState = new AutomationProperty<WindowInteractionState>(() => Properties.WindowInteractionStateProperty, BasicAutomationElement);
            WindowVisualState = new AutomationProperty<WindowVisualState>(() => Properties.WindowVisualStateProperty, BasicAutomationElement);
        }

        public IWindowPatternProperties Properties => Automation.PropertyLibrary.Window;
        public IWindowPatternEvents Events => Automation.EventLibrary.Window;

        public AutomationProperty<bool> CanMaximize { get; }
        public AutomationProperty<bool> CanMinimize { get; }
        public AutomationProperty<bool> IsModal { get; }
        public AutomationProperty<bool> IsTopmost { get; }
        public AutomationProperty<WindowInteractionState> WindowInteractionState { get; }
        public AutomationProperty<WindowVisualState> WindowVisualState { get; }

        public abstract void Close();
        public abstract void SetWindowVisualState(WindowVisualState state);
        public abstract bool WaitForInputIdle(int milliseconds);
    }
}