module App.About
open Fable.Helpers.Vue

let view =
    h1 [ Class [ "q-pa-xl", true ] ]
        [ str "Fable Elmish Vue Quasar Demo" ]
