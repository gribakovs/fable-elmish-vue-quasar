module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map About (s "about")
        map Page.Counter (s "counter")
    ]

let urlUpdate (result: Option<Page>) model =
    match result with
    | None -> model, toHash model.page |> Navigation.modifyUrl
    | Some page -> { model with page = page }, Cmd.none

let init result =
    { showLeft = true; page = About; counter = Counter.State.init () }
    |> urlUpdate result

let update msg model =
    match msg with
    | SetLeft showLeft -> { model with showLeft = showLeft }
    | Counter msg ->
        { model with counter = Counter.State.update msg model.counter
        }
    | SetPage page -> { model with page = page }
    , Cmd.none
