# Fluxor WPF Application

A Windows Presentation Foundation (WPF) application demonstrating state management using the Fluxor library. The application features a sidebar navigation with two main pages: Counter and Image controls.

## Features

### Counter Page
- Simple increment and decrement functionality
- State managed through Fluxor store
- Clean, modern UI with large buttons

### Image Controls Page
- Three separate controls for Gain, Width, and Zoom
- Each control has increment (+) and decrement (-) buttons
- Values range from 0 to 100
- Buttons automatically disable when limits are reached
- Real-time state management with Fluxor

### Events Page
- Real-time event logging of all state changes
- Displays timestamp, event type, description, and details
- Shows both Counter and Image control interactions
- Clear Events button to reset the log
- Automatic scrolling to show latest events

## Architecture

### State Management
The application uses **Fluxor** for predictable state management:

- **States**: Immutable records that hold the application state
  - `CounterState`: Contains the counter value
  - `ImageState`: Contains Gain, Width, and Zoom values (0-100 range)
  - `EventsState`: Contains immutable list of event log entries

- **Actions**: Simple classes that describe what happened
  - Counter: `IncrementCounterAction`, `DecrementCounterAction`
  - Image: `IncrementGainAction`, `DecrementGainAction`, `IncrementWidthAction`, `DecrementWidthAction`, `IncrementZoomAction`, `DecrementZoomAction`
  - Events: `LogEventAction`, `ClearEventsAction`

- **Reducers**: Pure functions that calculate the new state based on the current state and action
  - Automatically clamp values to valid ranges (0-100 for image controls)

### UI Components
- **MainWindow**: Contains the sidebar navigation and content area
- **CounterView**: User control for the counter functionality
- **ImageView**: User control for image parameter controls with button state management
- **EventsView**: User control for displaying real-time event logs with DataGrid

## Technology Stack

- **.NET 9.0** - Target framework
- **WPF** - User interface framework
- **Fluxor 6.0.0** - State management library
- **Microsoft.Extensions.Hosting** - Dependency injection and hosting
- **Microsoft.Extensions.DependencyInjection** - Service container

## Project Structure

```
├── .github/
│   └── copilot-instructions.md    # GitHub Copilot workspace instructions
├── Store/                         # Fluxor state management
│   ├── Counter/
│   │   ├── CounterActions.cs      # Counter actions
│   │   ├── CounterReducers.cs     # Counter reducers
│   │   └── CounterState.cs        # Counter state
│   └── Image/
│       ├── ImageActions.cs        # Image control actions
│       ├── ImageReducers.cs       # Image control reducers
│       └── ImageState.cs          # Image control state
├── Views/                         # User controls
│   ├── CounterView.xaml           # Counter page UI
│   ├── CounterView.xaml.cs        # Counter page logic
│   ├── ImageView.xaml             # Image controls UI
│   └── ImageView.xaml.cs          # Image controls logic
├── ViewModels/                    # (Reserved for future use)
├── App.xaml                       # Application definition
├── App.xaml.cs                    # Application startup and DI setup
├── MainWindow.xaml                # Main window UI
├── MainWindow.xaml.cs             # Main window logic
└── FluxorWpfApp.csproj           # Project file
```

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 or Visual Studio Code

### Building and Running

1. **Clone or download** the project to your local machine

2. **Navigate** to the project directory:
   ```bash
   cd fluxor-for-wpf
   ```

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Build the project**:
   ```bash
   dotnet build
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

### Debugging in Visual Studio Code

1. Open the project folder in Visual Studio Code
2. Press `F5` to start debugging
3. The application will launch with the debugger attached

## Usage

### Navigation
- Use the sidebar buttons on the left to switch between pages
- **Counter**: Navigate to the simple counter functionality
- **Image**: Navigate to the image parameter controls

### Counter Page
- Click the **+** button to increment the counter
- Click the **-** button to decrement the counter
- The value updates instantly and persists while navigating between pages

### Image Controls Page
- Each parameter (Gain, Width, Zoom) has its own increment/decrement buttons
- Values are constrained between 0 and 100
- When a value reaches 0, the decrement (-) button becomes disabled
- When a value reaches 100, the increment (+) button becomes disabled
- All values start at 50 by default

## Key Features Demonstrated

1. **Fluxor State Management**: Predictable state updates using actions and reducers
2. **Dependency Injection**: Services are properly registered and resolved
3. **Reactive UI**: UI automatically updates when state changes
4. **Button State Management**: Buttons disable/enable based on business rules
5. **Navigation**: Page-based navigation with state preservation
6. **Modern WPF**: Clean, styled UI components with proper theming

## Development Notes

- State is immutable and can only be changed through dispatched actions
- UI components subscribe to state changes and update automatically
- All state management logic is separated from UI logic
- The application uses proper dependency injection patterns
- Null safety is handled throughout the application

## Future Enhancements

- Add more complex state interactions
- Implement effects for side effects (API calls, etc.)
- Add state persistence
- Implement undo/redo functionality
- Add more sophisticated UI animations