module App.Main
open Elmish
open Elmish.Debug
open Elmish.HMR
open Elmish.Vue
open Fable.Helpers.Quasar
open Fable.Helpers.Vue
open Fable.Core.JsInterop

type Model = {
    count: int
    total: int
}
type Msg = Decrease | Increase | Reset

let init () = {
    count = 0
    total = 0
}

let butt color text dispatch msg =
    qBtn [
        Style [
            sprintf "hsl(%i,40%%,60%%)" color |> BackgroundColor
            Color "white"
            Width "100%"
        ]
        On [ Click <| fun _ -> dispatch msg ]
        Class [ "q-ma-xl", true ]
    ] [ str text ]

let view model dispatch =
    div [] [
        div [ Class [ "row", true; "no-wrap", true ] ] [
            butt 0 "-" dispatch Decrease
            h1 [ Class [ "q-ma-xl", true ] ] [ string model.count |> str ]
            butt 120 "+" dispatch Increase
            h1 [ Class [ "q-ma-xl", true ] ] [ string model.total |> str ]
            butt 240 "Reset" dispatch Reset
        ]
        [ "alarm"; "cloud"; "thumb_up"; "mail"; "map" ]
            |> List.map (fun name ->
                qIcon [
                    Props [ Name name ]
                    Style [ unbox ("font-size", "48px") ]
                ] []
            )
            |> div [ Class [ "row", true; "justify-around", true ] ]
        qBtn [
            Class [ "q-ma-xl", true ]
            On [ Click <| fun _ ->
                // do !!jsThis?``$q``?create "Clicked!"
                notify.create "Clicked!"
            ]
        ] [ str "Notify" ]
    ]

let update cmd model =
    let count f = {
        model with
            count = f model.count 1
            total = model.total + 1
    }
    match cmd with
    | Decrease -> count (-)
    | Increase -> count (+)
    | Reset -> { model with count = 0 }

do Program.mkSimple init update view
#if DEBUG
    |> Program.withDebugger
    // |> Program.withHMR
#endif
    |> Program.withVue "#app"
    |> Program.run