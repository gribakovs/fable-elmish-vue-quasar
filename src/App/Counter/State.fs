module Counter.State
open Types

let init () = { count = 0; total = 0 }

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
