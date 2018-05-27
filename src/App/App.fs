module App.Main
open Elmish
open Elmish.Debug
open Elmish.HMR
open Elmish.Vue
open Fable.Core
open Fable.Helpers.Quasar
open Fable.Helpers.Vue

type Page = About | Counter
type Model = { showLeft: bool; page: Page; counter: Counter.Model }
type Msg = SetLeft of bool | Counter of Counter.Msg | SetPage of Page

do JsInterop.importAll "./styles/app.styl"
let init () =
    { showLeft = true; page = About; counter = Counter.init () }

let btn page dispatch =
    qBtn [
        Props [ Flat true ]
        On [ Click <| fun _ -> SetPage page |> dispatch ]
    ] [ string page |> str ]

let view model dispatch =
    let page = function
        | About -> About.view
        | Page.Counter ->
            Counter.view model.counter (Counter >> dispatch)
    qLayout [ Props [ View "lHh lpr lFf" ] ] [
        qLayoutHeader [] [
            qToolbar [] [
                qBtn [
                    Props [
                        Flat true; Round true; Dense true; Icon "menu"
                    ]
                    On [ Click <| fun _ ->
                        not model.showLeft |> SetLeft |> dispatch
                    ]
                ] []
                qToolbarTitle [] [ string model.page |> str ]
                btn Page.About dispatch
                btn Page.Counter dispatch
                qSearch
                    [ Props [ Inverted true; Prop.Color "none" ] ] []
            ]
        ]
        qLayoutDrawer [
            Props [ Value model.showLeft ]
            On  [ Input (unbox >> SetLeft >> dispatch) ]
        ] [ qList [
                Props [ NoBorder true; InsetSeparator true ]
            ] [ qListHeader [] [ str "Left drawer" ]
                qItem [] [ str "About" ]
                qItem [] [ str "Counter" ]
            ]
        ]
        page model.page
    ]

let update msg model =
    match msg with
    | SetLeft showLeft -> { model with showLeft = showLeft }
    | Counter msg ->
        { model with counter = Counter.update msg model.counter }
    | SetPage page -> { model with page = page }

do Program.mkSimple init update view
#if DEBUG
    |> Program.withDebugger
    // |> Program.withHMR // doesn't
#endif
    |> Program.withVue "#app"
    |> Program.run
