module Fable.Helpers.Quasar
open Fable.Core
open Fable.Import
open Fable.Helpers

do JsInterop.importAll "./styles/quasar.styl"
// do JsInterop.importAll "quasar-extras/animate"
[<Import("default","quasar-framework/dist/quasar.mat.esm")>]
let quasar: U2<Plugin.PluginObject<obj>,Plugin.PluginFunction<obj>> = jsNative

[<Import("QBtn","quasar-framework/dist/quasar.mat.esm")>]
let QBtn: Options.Component<obj option,obj option,obj option,obj option> = jsNative

let el tag = U4.Case2 tag |> Vue.vNode
let qBtn = el QBtn
// let qBtn = Vue.el "QBtn"