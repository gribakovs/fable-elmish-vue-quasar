module App.About
open Fable.Helpers.Vue
open Fable.Helpers.Quasar

let view =
    div [] [
        qPageContainer [] [
            div [
                Style [ BackgroundColor "#fff" ]
                Class [ "shadow-1", true; "q-ma-lg", true ]
            ] [ h1 [
                    Style [ TextAlign "center" ]
                    Class [ "q-ma-lg", true ]
                ] [ str "Fable Elmish Vue Quasar Demo" ]
            ]
        ]
        qLayoutDrawer [ Props [ Side "right"; Value true ] ] [
            qList [
                Props [ NoBorder true; InsetSeparator true ]
            ] [ qListHeader [] [ str "About's drawer" ]
                qItem [] [ str "About" ]
                qItem [] [ str "Counter" ]
            ]
        ]
    ]
