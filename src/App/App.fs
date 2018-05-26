module App.Main
open Elmish
open Elmish.Debug
open Elmish.HMR
open Elmish.Vue
open Fable.Helpers.Quasar
open Fable.Helpers.Vue

type Page = About | Counter
type Model = { page: Page; counter: Counter.Model }
type Msg = Counter of Counter.Msg | ChangePage of Page
let init () = { page = About; counter = Counter.init () }

let btn page dispatch =
    qBtn [ On [ Click <| fun _ -> ChangePage page |> dispatch ] ]
        [ string page |> str ]

let view model dispatch =
    let page = function
        | About -> About.view
        | Page.Counter ->
            Counter.view model.counter (Counter >> dispatch)
    div [] [
        div [ Class [ "q-pa-xl", true; "row", true; "justify-around", true ] ] [
            btn Page.About dispatch
            btn Page.Counter dispatch
        ]
        page model.page
    ]

let update msg model =
    match msg with
    | Counter msg ->
        { model with counter = Counter.update msg model.counter }
    | ChangePage page -> { model with page = page }

do Program.mkSimple init update view
#if DEBUG
    |> Program.withDebugger
    // |> Program.withHMR // doesn't
#endif
    |> Program.withVue "#app"
    |> Program.run
