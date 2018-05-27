module App.About
open Fable.Helpers.Vue
open Fable.Helpers.Quasar

let view =
    div [] [
        qPageContainer [] [
            h1 [
                Style [ BackgroundColor "#fff" ]
                Class [ "q-ma-lg", true ]
            ] [ str "Fable Elmish Vue Quasar Demo" ]
        ]
        qLayoutDrawer [ Props [ Side "right"; Value true ] ] [
            qList [
                Props [ ``No-border`` true; ``Inset-separator`` true ]
            ] [ qListHeader [] [ str "About's drawer" ]
                qItem [] [ str "About" ]
                qItem [] [ str "Counter" ]
            ]
        ]
    ]
