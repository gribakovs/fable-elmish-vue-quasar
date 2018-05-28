module Counter.View
open Fable.Helpers.Quasar
open Fable.Helpers.Vue
open Types

let private butt color text dispatch msg =
    qBtn [
        Style [
            sprintf "hsl(%i,40%%,60%%)" color |> BackgroundColor
            CSSProp.Color "white"
            Width "100%"
        ]
        On [ Click <| fun _ -> dispatch msg ]
    ] [ str text ]

let private number num =
    div [ Class [ "q-pa-lg", true ] ] [ string num |> str ]

let root model dispatch =
    div [] [
        qPageContainer [] [
            // qToolbar [] [ qToolbarTitle [] [ str "Toolbar" ] ]
            div [
                Style [ BackgroundColor "#fff" ]
                Class [ "shadow-5", true; "q-ma-lg", true; "q-pa-lg", true ]
            ] [ div [
                    Class [
                        "row", true
                        "no-wrap", true
                        "items-center", true
                    ]
                ] [ butt 0 "-" dispatch Decrease
                    number model.count
                    butt 90 "+" dispatch Increase
                    number model.total
                    butt 180 "Reset" dispatch Reset
                ]
                [ "alarm"; "cloud"; "thumb_up"; "mail"; "map" ]
                    |> List.map (fun name ->
                        qIcon [
                            Props [ Name name ]
                            Style [ unbox ("font-size", "48px") ]
                        ] []
                    )
                    |> div [
                        Class [ "row", true; "justify-between", true ]
                    ]
                br []
                butt 270 "Notify" notify.create "Clicked!"
            ]
            qLayoutDrawer [ Props [ Side "right"; Value true ] ] [
                qList [
                    Props [ NoBorder true; InsetSeparator true ]
                ] [ qListHeader [] [ str "Counter's drawer" ]
                    qItem [] [ str "About" ]
                    qItem [] [ str "Counter" ]
                ]
            ]
        ]
    ]
