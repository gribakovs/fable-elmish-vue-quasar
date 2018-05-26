module Fable.Helpers.Quasar
open Fable.Core
open Fable.Import
open Fable.Helpers

type Component =
    Options.Component<obj option,obj option,obj option,obj option>

do JsInterop.importAll "./styles/quasar.styl"
do JsInterop.importAll "quasar-extras/animate"
do JsInterop.importAll "quasar-extras/material-icons"
[<Import("default","quasar")>]
let quasar: U2<Plugin.PluginObject<obj>,Plugin.PluginFunction<obj>> =
    jsNative

let el tag = U4.Case2 tag |> Vue.vNode
let [<Import("QBtn","quasar")>] QBtn: Component = jsNative
let qBtn = el QBtn
let [<Import("QIcon","quasar")>] QIcon: Component = jsNative
let qIcon = el QIcon
let [<Import("QLayout","quasar")>] QLayout: Component = jsNative
let qLayout = el QLayout
let [<Import("QLayoutHeader","quasar")>] QLayoutHeader: Component = jsNative
let qLayoutHeader = el QLayoutHeader
let [<Import("QPageContainer","quasar")>] QPageContainer: Component = jsNative
let qPageContainer = el QPageContainer
let [<Import("QToolbar","quasar")>] QToolbar: Component = jsNative
let qToolbar = el QToolbar
let [<Import("QToolbarTitle","quasar")>] QToolbarTitle: Component = jsNative
let qToolbarTitle = el QToolbarTitle
let [<Import("QLayoutDrawer","quasar")>] QLayoutDrawer: Component = jsNative
let qLayoutDrawer = el QLayoutDrawer

type INotify =
    abstract create: string -> unit
let [<Import("Notify","quasar")>] notify: INotify = jsNative
