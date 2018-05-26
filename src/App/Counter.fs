module App.Counter
open Fable.Helpers.Quasar
open Fable.Helpers.Vue

type Model = { count: int; total: int }
type Msg = Decrease | Increase | Reset
let init () = { count = 0; total = 0 }

let private butt color text dispatch msg =
    qBtn [
        Style [
            sprintf "hsl(%i,40%%,60%%)" color |> BackgroundColor
            Color "white"
            Width "100%"
        ]
        On [ Click <| fun _ -> dispatch msg ]
    ] [ str text ]

let private number num =
    div [ Class [ "q-pa-xl", true ] ] [ string num |> str ]

let view model dispatch =
    div [ Class [ "q-pa-xl", true ] ] [
        div [
            Class
              [ "row", true; "no-wrap", true; "items-center", true ]
        ] [ butt 0 "-" dispatch Decrease
            number model.count
            butt 120 "+" dispatch Increase
            number model.total
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
        br []
        qBtn [ On [ Click <| fun _ -> notify.create "Clicked!" ] ]
            [ str "Notify" ]
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
    | Reset -> { model with count = 0; total = 0 }
