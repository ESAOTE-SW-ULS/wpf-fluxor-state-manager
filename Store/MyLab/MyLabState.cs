using Fluxor;

namespace FluxorWpfApp.Store.MyLab
{
    [FeatureState]
    public record MyLabState
    {
        public SessionState Session { get; init; }
        public ScanState Scan { get; init; }
        public BModeState BMode { get; init; }
        public DepthState Depth { get; init; }
        public FrequencyState Frequency { get; init; }
        public FocusState Focus { get; init; }
        public DynamicRangeState DynamicRange { get; init; }

        public MyLabState()
        {
            Session = new SessionState();
            Scan = new ScanState();
            BMode = new BModeState();
            Depth = new DepthState();
            Frequency = new FrequencyState();
            Focus = new FocusState();
            DynamicRange = new DynamicRangeState();
        }
    }

    // Session State
    public record SessionState
    {
        public Patient? Patient { get; init; }
        public SessionStatus Status { get; init; }

        public SessionState()
        {
            Status = SessionStatus.Inactive;
        }
    }

    public record Patient
    {
        public string? Name { get; init; }
        public string? Id { get; init; }
    }

    public enum SessionStatus
    {
        Active,
        Inactive,
        Suspended
    }

    // Scan State
    public record ScanState
    {
        public ScanStatus Status { get; init; }

        public ScanState()
        {
            Status = ScanStatus.Stopped;
        }
    }

    public enum ScanStatus
    {
        Running,
        Stopped,
        Frozen
    }

    // BMode State
    public record BModeState
    {
        public GainState Gain { get; init; }

        public BModeState()
        {
            Gain = new GainState { Value = 50 };
        }
    }

    public record GainState
    {
        public int Value { get; init; }
    }

    // Depth State
    public record DepthState
    {
        public int Value { get; init; }

        public DepthState()
        {
            Value = 100;
        }
    }

    // Frequency State
    public record FrequencyState
    {
        public int Value { get; init; }

        public FrequencyState()
        {
            Value = 7;
        }
    }

    // Focus State
    public record FocusState
    {
        public int Value { get; init; }

        public FocusState()
        {
            Value = 50;
        }
    }

    // Dynamic Range State
    public record DynamicRangeState
    {
        public int Value { get; init; }

        public DynamicRangeState()
        {
            Value = 60;
        }
    }
}
