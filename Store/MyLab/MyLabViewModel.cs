using Fluxor;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace FluxorWpfApp.Store.MyLab
{
    public class MyLabViewModel : INotifyPropertyChanged
    {
        private readonly IState<MyLabState> _myLabState;
        private readonly IDispatcher _dispatcher;
        
        private string _patientName = "John Doe";
        private string _patientId = "12345";
        private int _gainValue = 50;
        private int _depthValue = 100;
        private int _frequencyValue = 7;
        private int _focusValue = 50;
        private int _dynamicRangeValue = 60;

        public event PropertyChangedEventHandler PropertyChanged;

        public MyLabViewModel(IState<MyLabState> myLabState, IDispatcher dispatcher)
        {
            _myLabState = myLabState;
            _dispatcher = dispatcher;

            // Subscribe to state changes
            _myLabState.StateChanged += (sender, args) => OnStateChanged();

            // Initialize commands
            StartSessionCommand = new RelayCommand(StartSession);
            EndSessionCommand = new RelayCommand(EndSession);
            StartScanCommand = new RelayCommand(StartScan);
            FreezeScanCommand = new RelayCommand(FreezeScan);
            StopScanCommand = new RelayCommand(StopScan);
        }

        // Properties
        public string PatientName
        {
            get => _patientName;
            set
            {
                _patientName = value;
                OnPropertyChanged();
            }
        }

        public string PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged();
            }
        }

        public string SessionStatusText => _myLabState.Value?.Session?.Status.ToString() ?? "Inactive";
        public string ScanStatusText => _myLabState.Value?.Scan?.Status.ToString() ?? "Stopped";

        public int GainValue
        {
            get => _gainValue;
            set
            {
                if (_gainValue != value)
                {
                    _gainValue = value;
                    OnPropertyChanged();
                    UpdateGain(value);
                }
            }
        }

        public int DepthValue
        {
            get => _depthValue;
            set
            {
                if (_depthValue != value)
                {
                    _depthValue = value;
                    OnPropertyChanged();
                    UpdateDepth(value);
                }
            }
        }

        public int FrequencyValue
        {
            get => _frequencyValue;
            set
            {
                if (_frequencyValue != value)
                {
                    _frequencyValue = value;
                    OnPropertyChanged();
                    UpdateFrequency(value);
                }
            }
        }

        public int FocusValue
        {
            get => _focusValue;
            set
            {
                if (_focusValue != value)
                {
                    _focusValue = value;
                    OnPropertyChanged();
                    UpdateFocus(value);
                }
            }
        }

        public int DynamicRangeValue
        {
            get => _dynamicRangeValue;
            set
            {
                if (_dynamicRangeValue != value)
                {
                    _dynamicRangeValue = value;
                    OnPropertyChanged();
                    UpdateDynamicRange(value);
                }
            }
        }

        public string StateDebugInfo
        {
            get
            {
                var state = _myLabState.Value;
                if (state == null) return "State not initialized";

                var sb = new StringBuilder();
                sb.AppendLine($"Session Status: {state.Session?.Status}");
                sb.AppendLine($"Patient: {state.Session?.Patient?.Name} (ID: {state.Session?.Patient?.Id})");
                sb.AppendLine();
                sb.AppendLine($"Scan Status: {state.Scan?.Status}");
                sb.AppendLine();
                sb.AppendLine("B-Mode Settings:");
                sb.AppendLine($"  Gain: {state.BMode?.Gain?.Value ?? 0}");
                sb.AppendLine($"  Depth: {state.Depth?.Value ?? 0}");
                sb.AppendLine($"  Frequency: {state.Frequency?.Value ?? 0} MHz");
                sb.AppendLine($"  Focus: {state.Focus?.Value ?? 0}");
                sb.AppendLine($"  Dynamic Range: {state.DynamicRange?.Value ?? 0}");

                return sb.ToString();
            }
        }

        // Commands
        public ICommand StartSessionCommand { get; }
        public ICommand EndSessionCommand { get; }
        public ICommand StartScanCommand { get; }
        public ICommand FreezeScanCommand { get; }
        public ICommand StopScanCommand { get; }

        // Command Methods
        private void StartSession()
        {
            var newSession = new SessionState
            {
                Status = SessionStatus.Active,
                Patient = new Patient
                {
                    Name = PatientName,
                    Id = PatientId
                }
            };

            _dispatcher.Dispatch(new ChangeSessionAction(newSession));
        }

        private void EndSession()
        {
            var newSession = new SessionState
            {
                Status = SessionStatus.Inactive,
                Patient = _myLabState.Value?.Session?.Patient
            };

            _dispatcher.Dispatch(new ChangeSessionAction(newSession));
        }

        private void StartScan()
        {
            var newScanState = new ScanState
            {
                Status = ScanStatus.Running
            };

            _dispatcher.Dispatch(new ChangeScanAction(newScanState));
        }

        private void FreezeScan()
        {
            var newScanState = new ScanState
            {
                Status = ScanStatus.Frozen
            };

            _dispatcher.Dispatch(new ChangeScanAction(newScanState));
        }

        private void StopScan()
        {
            var newScanState = new ScanState
            {
                Status = ScanStatus.Stopped
            };

            _dispatcher.Dispatch(new ChangeScanAction(newScanState));
        }

        private void UpdateGain(int value)
        {
            var newGain = new GainState { Value = value };
            _dispatcher.Dispatch(new ChangeGainAction(newGain));
        }

        private void UpdateDepth(int value)
        {
            var newDepth = new DepthState { Value = value };
            _dispatcher.Dispatch(new ChangeDepthAction(newDepth));
        }

        private void UpdateFrequency(int value)
        {
            var newFrequency = new FrequencyState { Value = value };
            _dispatcher.Dispatch(new ChangeFrequencyAction(newFrequency));
        }

        private void UpdateFocus(int value)
        {
            var newFocus = new FocusState { Value = value };
            _dispatcher.Dispatch(new ChangeFocusAction(newFocus));
        }

        private void UpdateDynamicRange(int value)
        {
            var newDynamicRange = new DynamicRangeState { Value = value };
            _dispatcher.Dispatch(new ChangeDynamicRangeAction(newDynamicRange));
        }

        // State change handler
        private void OnStateChanged()
        {
            OnPropertyChanged(nameof(SessionStatusText));
            OnPropertyChanged(nameof(ScanStatusText));
            OnPropertyChanged(nameof(StateDebugInfo));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            // State change handler is now a lambda, no need to unsubscribe
        }
    }
}
