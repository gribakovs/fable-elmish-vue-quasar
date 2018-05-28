module App.View
open App.State
open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.Debug
open Elmish.HMR
open Elmish.Vue
open Fable.Core
open Fable.Helpers.Quasar
open Fable.Helpers.Vue
open Global
open Types

do JsInterop.importAll "./styles/app.styl"

let root model dispatch =
    let menuItem letter page =
        qItem [
            Attrs [ toHash page |> (+) "/" |> Href ]
            Props [ Tag "a" ]
            // Style [ TextDecoration "none" ]
        ] [ qItemSide [ Props [ Letter letter ] ] []
            string page |> str
        ]
    let page = function
        | About -> About.View.root
        | Page.Counter ->
            Counter.View.root model.counter (Msg.Counter >> dispatch)
    qLayout [
        Attrs [ Id "app" ] // WORKAROUND
        Props [ View "lHr LpR lFf" ]
    ] [ qLayoutHeader [] [
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
                qSearch
                    [ Props [ Inverted true; Prop.Color "none" ] ] []
            ]
        ]
        qLayoutDrawer [
            Props [ Value model.showLeft ]
            On  [ Input (unbox >> SetLeft >> dispatch) ]
        ] [ qList [
                Props
                    [ NoBorder true; InsetSeparator true; Link true ]
            ] [ qListHeader [] [ str "Left drawer" ]
                menuItem 'A' About
                menuItem 'C' Page.Counter
            ]
        ]
        page model.page
    ]

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
//-:cnd:noEmit
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
//+:cnd:noEmit
|> Program.withVue "#app"
|> Program.run
