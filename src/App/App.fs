module App.Main
open Elmish
open Elmish.Debug
open Elmish.HMR
open Elmish.Vue

do Program.mkSimple Counter.init Counter.update Counter.view
#if DEBUG
    |> Program.withDebugger
    // |> Program.withHMR // doesn't
#endif
    |> Program.withVue "#app"
    |> Program.run