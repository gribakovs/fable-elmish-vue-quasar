module App.Types
open Global

type Model =
    { showLeft: bool; page: Page; counter: Counter.Types.Model }

type Msg =
    SetLeft of bool | Counter of Counter.Types.Msg | SetPage of Page
