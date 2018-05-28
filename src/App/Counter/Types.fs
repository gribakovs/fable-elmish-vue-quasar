module Counter.Types

type Model = { count: int; total: int }
type Msg = Decrease | Increase | Reset
