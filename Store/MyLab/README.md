# MyLab Fluxor WPF Demo

This WPF application demonstrates the MyLabFluxor state management implementation using Fluxor.

## Features

The MyLab view provides a complete demonstration of:

### 1. Session Management
- Start/end sessions with patient information
- Patient name and ID input
- Real-time session status display

### 2. Scan Control
- Start scanning
- Freeze scan
- Stop scan
- Real-time scan status updates

### 3. B-Mode Settings
- **Gain Control** (0-100): Adjust signal amplification
- **Depth Control** (0-200): Control imaging depth
- **Frequency Control** (1-15 MHz): Set probe frequency
- **Focus Control** (0-100): Adjust focal zone
- **Dynamic Range Control** (0-100): Set display dynamic range

### 4. State Debug View
- Real-time display of current state values
- Helps understand how state changes propagate

## How It Works

### State Management Architecture

```
UI (View) → ViewModel → Dispatcher → Actions → Reducers → State → ViewModel → UI
```

1. **User Interaction**: User adjusts a slider or clicks a button
2. **ViewModel**: Dispatches an action with the new value
3. **Fluxor**: Routes action to appropriate reducer
4. **Reducer**: Creates new state with updated values
5. **State Change**: Fluxor notifies all subscribers
6. **UI Update**: ViewModel receives update and notifies UI

### Key Files

- **MyLabState.cs**: Defines all state structures (immutable records)
- **MyLabActions.cs**: Defines actions that trigger state changes
- **MyLabReducers.cs**: Pure functions that create new state
- **MyLabViewModel.cs**: Connects UI to Fluxor state management
- **MyLabView.xaml**: WPF UI definition

## Running the Application

1. Build and run the solution
2. Click "🏥 MyLab" in the sidebar
3. Interact with the controls to see state management in action

## Example Workflows

### Starting a Session
1. Enter patient name (e.g., "John Doe")
2. Enter patient ID (e.g., "12345")
3. Click "Start Session"
4. Observe session status change to "Active"

### Adjusting B-Mode Settings
1. Move any slider (e.g., Gain)
2. Observe the value update in real-time
3. Check the debug view to see state changes
4. Notice how the state is immutable - each change creates a new state

### Scanning Workflow
1. Start a session first
2. Click "Start Scan" to begin scanning
3. Click "Freeze" to freeze the current image
4. Click "Stop" to end scanning

## Fluxor Benefits Demonstrated

1. **Predictable State Changes**: All state changes go through reducers
2. **Immutability**: State cannot be accidentally modified
3. **Debugging**: Debug view shows exact state at any moment
4. **Time Travel**: Could easily add undo/redo functionality
5. **Testability**: Reducers are pure functions, easy to test
6. **Separation of Concerns**: UI, business logic, and state are separated

## Extending the Application

### Adding a New Control

1. **Add State** in `MyLabState.cs`:
```csharp
public record MyNewState
{
    public int Value { get; init; }
}
```

2. **Add Action** in `MyLabActions.cs`:
```csharp
public record ChangeMyNewAction(MyNewState Payload);
```

3. **Add Reducer** in `MyLabReducers.cs`:
```csharp
[ReducerMethod]
public static MyLabState ReduceChangeMyNewAction(MyLabState state, ChangeMyNewAction action)
{
    return state with { MyNew = action.Payload };
}
```

4. **Add UI** in `MyLabView.xaml` and bind to ViewModel property

5. **Add ViewModel Property** in `MyLabViewModel.cs`:
```csharp
public int MyNewValue
{
    get => _myNewValue;
    set
    {
        if (_myNewValue != value)
        {
            _myNewValue = value;
            OnPropertyChanged();
            UpdateMyNew(value);
        }
    }
}
```

## Comparison with Redux

This implementation follows the same patterns as the original MyLabRedux, but with:
- ✅ Less boilerplate code
- ✅ Better type safety
- ✅ Immutable state by default
- ✅ Modern C# features (records, with expressions)
- ✅ First-class WPF support

## Additional Resources

- See `MyLabFluxor/README.md` for detailed implementation guide
- See `MyLabFluxor/COMPARISON.md` for Redux vs Fluxor comparison
- Fluxor documentation: https://github.com/mrpmorris/Fluxor
