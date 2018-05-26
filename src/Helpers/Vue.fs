module Fable.Helpers.Vue
open Fable.Core
open Fable.Import

type VNodeThunk =
    VNodeThunk of (Vue.CreateElement -> U3<VNode.VNode, string, VNode.VNodeChildrenArrayContents>)

type CSSProp =
    | Color of string
    | BackgroundColor of string
    | Width of string

type EventHandler =
    | Click of (obj -> unit)
    | Input of (obj -> unit)

type ComponentKey = string

// type ComponentOptions<'Props,'State> =
//     | Components of obj
//     | El of U2<Browser.Element, string>
//     | Props of 'Props
//     | Render of (Vue.CreateElement -> VNode.VNode)

type Class = string * bool

type Prop =
    | Dense of bool
    | Flat of bool
    | Icon of string
    | Name of string
    | View of string
    | Round of bool
    | Value of bool
    | Inverted
    | Color of string
    | ``No-border``
    | ``Inset-separator``

type DataProp =
    | Style of CSSProp list
    | On of EventHandler list
    | Class of Class list
    | Props of Prop List
    | DomProps of Prop List

let inline Style (css: CSSProp list): DataProp =
    unbox ("style", JsInterop.keyValueList CaseRules.LowerFirst css)

let inline On (handlers: EventHandler list): DataProp =
    unbox ("on", JsInterop.keyValueList CaseRules.LowerFirst handlers)

let str s = VNodeThunk <| fun _ -> U3.Case2 s

let vNode tag (data: DataProp list) children =
    VNodeThunk <| fun createElement ->
        createElement.Invoke (
            tag,
            JsInterop.keyValueList CaseRules.LowerFirst data |> unbox,
            List.map
                (fun (VNodeThunk t) -> t createElement)
                children
                |> Array.ofList
                |> unbox
                |> U3.Case1
        ) |> U3.Case1

let el tag = U4.Case1 tag |> vNode
let button = el "button"
let div = el "div"
let h1 = el "h1"
let h2 = el "h2"
let h3 = el "h3"
let h4 = el "h4"
let h5 = el "h5"
let h6 = el "h6"
let span = el "span"
let br b = el "br" b []
