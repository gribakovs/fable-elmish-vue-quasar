module App.Main
open Elmish
open Elmish.Vue
open Fable.Helpers.Vue
open Fable.Helpers.Quasar
open Fable.Core.JsInterop

type Model = { count: int }
type Msg = Decrease | Increase | Reset

let init () = { count = 1 }

let butt color text dispatch msg =
    qBtn [
        Style [ sprintf "hsl(%i,40%%,60%%)" color |> BackgroundColor; Color "white"; Width "100%" ]
        On [ Click <| fun _ -> dispatch msg ]
    ] [ str text ]

let view model dispatch =
    div [
        Class [
            "row", true
            "justify-around", true
            "no-wrap", true
        ]
    ] [
        butt 0 "-" dispatch Decrease
        h1 [ Class [ "q-pa-xl", true ] ] [ string model.count |> str ]
        butt 90 "+" dispatch Increase
        butt 180 "Reset" dispatch Reset
    ]

let update cmd model =
    let count f = { model with count = f model.count 1 }
    match cmd with
    | Decrease -> count (-)
    | Increase -> count (+)
    | Reset -> { model with count = 0 }

do Program.mkSimple init update view
    |> Program.withVue "#app"
    |> Program.run