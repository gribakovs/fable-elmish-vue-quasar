module Fable.Helpers.Quasar
open Fable.Core
open Fable.Import
open Fable.Helpers

type Component =
    Options.Component<obj option,obj option,obj option,obj option>
    
do JsInterop.importAll "./styles/quasar.styl"
// do JsInterop.importAll "quasar-extras/animate"

[<Import("default","quasar")>]
let quasar: U2<Plugin.PluginObject<obj>,Plugin.PluginFunction<obj>> =
    jsNative

[<Import("QBtn","quasar")>] let QBtn: Component = jsNative
let el tag = U4.Case2 tag |> Vue.vNode
let qBtn = el QBtn