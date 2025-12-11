namespace FluxorWpfApp.Store.MyLab
{
    // Session Actions
    public record ChangeSessionAction(SessionState Payload);

    // Scan Actions
    public record ChangeScanAction(ScanState Payload);

    // BMode Actions
    public record ChangeGainAction(GainState Payload);

    // Depth Action
    public record ChangeDepthAction(DepthState Payload);

    // Frequency Action
    public record ChangeFrequencyAction(FrequencyState Payload);

    // Focus Action
    public record ChangeFocusAction(FocusState Payload);

    // Dynamic Range Action
    public record ChangeDynamicRangeAction(DynamicRangeState Payload);
}
