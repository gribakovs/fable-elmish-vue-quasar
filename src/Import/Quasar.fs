namespace rec Fable.Import

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module rec Quasar =
    // type PluginFunction = Vue.PluginFunction
    let [<Import("*","quasar")>] ``quasar-framework``: Quasar_framework.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract QBtn: IBtn
        abstract QCard: ICard
        abstract QCarousel: ICarousel
        abstract QKnob: IKnob
        abstract QSpinnerAudio: ISpinner
        abstract QSpinnerBall: ISpinner
        abstract QSpinnerBars: ISpinner
        abstract QSpinnerCircles: ISpinner
        abstract QSpinnerComment: ISpinner
        abstract QSpinnerCube: ISpinner
        abstract QSpinnerDots: ISpinner
        abstract QSpinnerFacebook: ISpinner
        abstract QSpinnerGears: ISpinner
        abstract QSpinnerGrid: ISpinner
        abstract QSpinnerHearts: ISpinner
        abstract QSpinnerHourglass: ISpinner
        abstract QSpinnerInfinity: ISpinner
        abstract QSpinnerIos: ISpinner
        abstract QSpinnerMat: ISpinner
        abstract QSpinnerOval: ISpinner
        abstract QSpinnerPie: ISpinner
        abstract QSpinnerPuff: ISpinner
        abstract QSpinnerRadio: ISpinner
        abstract QSpinnerRings: ISpinner
        abstract QSpinnerTail: ISpinner
        abstract ActionSheet: IActionSheet
        abstract Dialog: IDialog
        abstract AppFullscreen: IAppFullscreen
        abstract AppVisibility: IAppVisibility
        abstract Cookies: ICookies
        abstract Platform: IPlateform
        abstract Events: IEvents
        abstract Loading: ILoading
        abstract Toast: IToast
        abstract Utils: IUtils
        abstract LocalStorage: IWebStorage
        abstract SessionStorage: IWebStorage

    type [<AllowNullLiteral>] IBtn =
        /// Name of the icon to use. 
        abstract icon: string with get, set
        /// Name of the icon to place on right side of button. 
        abstract iconRight: string with get, set
        /// Display a spinner, if true. Can be optionally used along v-model. Check Button with Progress section. 
        abstract loader: bool with get, set
        /// Optional property for displaying a determinate progress. Use along loader. 
        abstract percentage: float option with get, set
        /// Optional property for displaying a determinate progress on a light button color. Use along loader and percentage. 
        abstract darkPercentage: bool option with get, set
        /// Set true, if you want a round button. 
        abstract round: bool with get, set
        /// Set true, if you want an outlined button. 
        abstract outline: bool with get, set
        /// Set true, if you want a flat button. 
        abstract flat: bool with get, set
        /// Set true, if the square button should have rounded corners. 
        abstract rounded: bool with get, set
        /// Set true, if the button should have a push effect. 
        abstract push: bool with get, set
        /// Set true, if the button should be small. 
        abstract small: bool with get, set
        /// Set true, if the button should be big. 
        abstract big: bool with get, set
        /// Set true, if the button should be glossy. 
        abstract glossy: bool with get, set
        /// The button is disabled, if true. @click event won’t be triggered while in this state. 
        abstract disable: bool with get, set
        /// A color from Quasar Color Palette. 
        abstract color: string with get, set
        /// Set true, if you don’t want button content/label to be transformed to uppercase letter on Material Theme. 
        abstract noCaps: bool with get, set

    type [<AllowNullLiteral>] ICard =
        /// Squared borders instead of round ones. 
        abstract square: bool with get, set
        /// Remove shadow. 
        abstract flat: bool with get, set
        /// Make it inline. Also set a CSS width to work. Take a look at Grid example on the “More Examples” section. 
        abstract ``inline``: bool with get, set
        /// One color from Quasar Color Palette. 
        abstract color: string with get, set

    type [<AllowNullLiteral>] ICarousel =
        /// Infinite slides scrolling 
        abstract infinite: bool with get, set
        /// Auto scrolls between slides. Works great along infinite prop (but infinite is not required). If used as a number, it represents the number of milliseconds between scrolls. 
        abstract autoplay: U2<bool, float> with get, set
        /// Show arrows 
        abstract arrows: bool with get, set
        /// Show dots at bottom 
        abstract dots: bool with get, set
        /// Boolean	Shows Fullscreen button 
        abstract fullscreen: bool with get, set
        /// Allow navigation with left and right arrow key 
        abstract handleArrowKeys: bool with get, set
        /// Show Actions slot 
        abstract actions: bool with get, set
        /// Show animation when slide changes. If used as number, represents the duration of the animation. Default is true, default duration is 300 ms.
        abstract animation: U2<bool, float> with get, set
        /// Disable swiping. 
        abstract noSwipe: bool with get, set
        /// Easing function used when changing slide from autoplay or button press. 
        abstract easing: (float -> float) with get, set
        /// Easing function used when changing slide with a swipe 
        abstract swipeEasing: (float -> float) with get, set
        /// Goes to next slide. 
        abstract next: ``done``: (unit -> unit) -> unit
        /// Goes to previous slide. 
        abstract previous: ``done``: (unit -> unit) -> unit
        /// Go to the desired slide. slideNumber is 0-based. 
        abstract goToSlide: slideNumber: float * ``done``: (unit -> unit) -> unit
        /// Toggles fullscreen mode. 
        abstract toggleFullscreen: unit -> unit

    type [<AllowNullLiteral>] IKnob =
        /// CSS String determining the width and height of the Knob. Examples: “120px”, “12rem”. 
        abstract size: string with get, set
        /// Number representing difference between two values that the model can take. Default: 1. 
        abstract step: float with get, set
        /// Minimum value that the model can take. 
        abstract min: float with get, set
        /// Maximum value that the model can take. 
        abstract max: float with get, set
        /// One from Quasar Color Palette. 
        abstract color: string with get, set
        /// String	One from Quasar Color Palette. 
        abstract trackColor: string with get, set
        /// Line width of Knob. Default is ‘6px’. 
        abstract lineWidth: string with get, set
        /// Sort of a “display” only mode. Model cannot be altered. 
        abstract readonly: bool with get, set
        /// When set to true the model cannot be altered. 
        abstract disable: bool with get, set

    type [<AllowNullLiteral>] ISpinner =
        abstract name: string with get, set
        abstract mixins: ResizeArray<obj option> with get, set

    type [<AllowNullLiteral>] ILoading =
        abstract show: ?options: ILoadingOptions -> unit
        abstract hide: unit -> unit
        abstract isActive: unit -> bool

    type [<AllowNullLiteral>] ILoadingOptions =
        abstract delay: float option with get, set
        abstract message: string option with get, set
        abstract messageColor: string option with get, set
        abstract spinner: ISpinner option with get, set
        abstract spinnerSize: float option with get, set
        abstract spinnerColor: string option with get, set

    type [<AllowNullLiteral>] IActionSheet =
        abstract create: options: IActionSheetOptions -> unit

    type [<AllowNullLiteral>] IActionSheetOptions =
        abstract title: string with get, set
        abstract gallery: bool option with get, set
        abstract actions: ResizeArray<IActionSheetAction> with get, set
        abstract dismiss: IActionSheetDismiss option with get, set

    type [<AllowNullLiteral>] IActionSheetAction =
        abstract label: string with get, set
        abstract icon: string option with get, set
        abstract avatar: string option with get, set
        abstract handler: Function with get, set

    type [<AllowNullLiteral>] IActionSheetDismiss =
        abstract label: string with get, set
        abstract icon: string option with get, set
        abstract classes: string option with get, set
        abstract handler: Function with get, set

    type [<AllowNullLiteral>] IToast =
        abstract create: IToastCreate with get, set
        abstract setDefaults: options: IToastOptions -> unit

    type [<AllowNullLiteral>] IToastOptions =
        abstract html: string with get, set
        abstract icon: string option with get, set
        abstract timeout: float option with get, set
        abstract button: IToastButton option with get, set
        abstract color: string option with get, set
        abstract bgColor: string option with get, set
        abstract onDismiss: Function option with get, set

    type [<AllowNullLiteral>] IToastButton =
        abstract label: string with get, set
        abstract handler: Function with get, set
        abstract color: string option with get, set

    type [<AllowNullLiteral>] IToastCreate =
        [<Emit "$0($1...)">] abstract Invoke: message: U2<string, IToastOptions> -> unit
        abstract positive: message: U2<string, IToastOptions> -> unit
        abstract negative: message: U2<string, IToastOptions> -> unit
        abstract warning: message: U2<string, IToastOptions> -> unit
        abstract info: message: U2<string, IToastOptions> -> unit

    type [<AllowNullLiteral>] IDialogCreate =
        [<Emit "$0($1...)">] abstract Invoke: options: DialogOptions -> unit

    type [<AllowNullLiteral>] IDialog =
        abstract create: IDialogCreate with get, set

    type [<AllowNullLiteral>] DialogOptionsButtons =
        abstract label: string with get, set
        abstract preventClose: bool option with get, set
        abstract classes: string option with get, set

    type [<AllowNullLiteral>] DialogOptionsButtonsHandler =
        inherit DialogOptionsButtons
        abstract handler: data: obj option * ?close: Function -> unit

    type [<AllowNullLiteral>] DialogOptionFrom =
        abstract ``type``: U6<string, string, string, string, string, string> with get, set
        abstract label: string with get, set
        abstract model: U2<string, ResizeArray<string>> option with get, set
        abstract min: float option with get, set
        abstract max: float option with get, set

    type [<AllowNullLiteral>] DialogOptions =
        abstract title: string option with get, set
        abstract message: string option with get, set
        abstract buttons: Array<U3<string, DialogOptionsButtons, DialogOptionsButtonsHandler>> option with get, set
        abstract stackButtons: bool option with get, set
        abstract nobuttons: bool option with get, set
        abstract progress: obj option option with get, set
        abstract form: obj option with get, set
        abstract onDismiss: Function option with get, set
        abstract noBackdropDismiss: bool option with get, set
        /// Can Dialog be dismissed by hitting Escape key?
        abstract noEscDismiss: bool option with get, set

    type [<AllowNullLiteral>] ITabs =
        abstract setActiveTab: name: string -> unit

    type [<AllowNullLiteral>] ITab =
        /// Make this Tab the selected one. 
        abstract activate: unit -> unit
        /// Unselect this Tab as the active one. 
        abstract deactivate: unit -> unit
        /// Sets the target as visible (true) or hides it (false). 
        abstract setTargetVisibility: visible: bool -> unit

    type [<AllowNullLiteral>] IAutoComplete =
        inherit Vue
        /// Trigger suggestions. 
        abstract trigger: unit -> unit
        /// Close suggestions popover. 
        abstract close: unit -> unit
        /// Close suggestions popover. 
        abstract setValue: unit -> unit
        /// Close suggestions popover. 
        abstract move: offset: float -> unit

    type [<AllowNullLiteral>] IchipsTextbox =
        inherit Vue
        /// Adds value to the model. 
        abstract add: value: string -> unit
        /// Removes value at index in model. 
        abstract remove: index: float -> unit
        /// Focuses the input text field. 
        abstract focus: unit -> unit

    type [<AllowNullLiteral>] IopenClose =
        inherit Vue
        abstract ``open``: unit -> unit
        abstract close: unit -> unit

    type [<AllowNullLiteral>] IOpenCloseToggle =
        inherit IopenClose
        abstract toggle: unit -> unit

    type [<AllowNullLiteral>] IDatetime =
        inherit IopenClose

    type [<AllowNullLiteral>] IInlineDatetime =
        inherit Vue
        /// Sets the year. 
        abstract setYear: year: float -> unit
        /// Sets the month (1 - 12).
        abstract setMonth: month: float -> unit
        /// Sets day of the month. 
        abstract setDay: day: float -> unit
        /// Toggles between AM and PM. 
        abstract toggleAmPm: unit -> unit
        /// Sets hour (0 - 23). 
        abstract setHour: hour: float -> unit
        /// Sets minute (0 - 59). 
        abstract setMinute: minute: float -> unit

    type [<AllowNullLiteral>] IRating =
        /// Parses and sets that value. 
        abstract set: value: float -> unit

    type [<AllowNullLiteral>] ISearch =
        /// Resets the model to an empty string. 
        abstract clear: unit -> unit

    type [<AllowNullLiteral>] ISelect =
        inherit IopenClose

    type [<AllowNullLiteral>] IDialogSelect =
        /// Opens up the Dialog so user can pick options. 
        abstract pick: unit -> unit

    type [<AllowNullLiteral>] IModal =
        inherit IOpenCloseToggle

    type [<AllowNullLiteral>] IDrawer =
        inherit IopenClose
        abstract setState: state: bool * ``done``: Function -> unit

    type [<AllowNullLiteral>] IQfab =
        inherit IOpenCloseToggle

    type [<AllowNullLiteral>] IAjaxBar =
        inherit Vue
        /// Where to place the loading bar: ‘top’, ‘bottom’, ‘left’ or ‘right’. Default: top’ 
        abstract position: U4<string, string, string, string> with get, set
        /// Thickness of loading bar. Default: ‘4px’ 
        abstract size: string with get, set
        /// One from Quasar Color Palette. Default: ‘red’ 
        abstract color: string with get, set
        /// How fast should loading bar update its value (in milliseconds). Default: 250 
        abstract speed: float with get, set
        /// How much should loading bar wait before showing loading bar after it’s triggered (in milliseconds). Default: 1000 
        abstract delay: float with get, set
        /// Reverse direction of loading bar. Default: false 
        abstract reverse: bool with get, set
        /// Trigger loading bar. 
        abstract start: unit -> unit
        /// Notify one event has finished.
        abstract stop: unit -> unit

    type [<AllowNullLiteral>] ICollapsible =
        inherit IOpenCloseToggle

    type [<AllowNullLiteral>] IContextMenu =
        inherit Vue
        abstract close: unit -> unit

    type [<AllowNullLiteral>] IDataTable =
        inherit Vue
        /// If parameter is missing or true then it puts Data Table in refresh mode. If parameter is false then components gets out of refresh mode. 
        abstract refresh: refreshMode: bool -> unit

    type [<AllowNullLiteral>] InfiniteScroll =
        inherit Vue
        /// Stops working, regardless of scroll position.
        abstract stop: unit -> unit
        /// Tells Infinite Scroll to load more content, regardless of the scroll position. 
        abstract loadMore: index: float * ``done``: Function -> unit
        /// Resets calling index to 0.
        abstract reset: unit -> unit
        /// Starts working.Checks scroll position upon call and if trigger is hit, it loads more content.
        abstract resume: unit -> unit
        /// Checks scroll position and loads more content if necessary.
        abstract poll: unit -> unit

    type [<AllowNullLiteral>] IImageGalery =
        inherit Vue
        /// Toggle thumbnails view. 
        abstract toggleQuickView: unit -> unit
        /// Go to a certain slide number (with animation or not).
        abstract goToSlide: index: float * animation: bool -> unit

    type [<AllowNullLiteral>] IPagination =
        inherit Vue
        /// Parses and sets page number to value.
        abstract set: value: float -> unit
        /// Parses and sets page number to current value + value.Negative values allowed. 
        abstract setByOffset: value: float -> unit

    type [<AllowNullLiteral>] IPopover =
        inherit IOpenCloseToggle

    type [<AllowNullLiteral>] ISlider =
        inherit Vue
        /// Go to respective slide, optionally with no animation (instantly).
        abstract goToSlide: slide: float * noAnimation: bool -> unit
        /// Toggles fullscreen mode 
        abstract toggleFullscreen: unit -> unit

    type [<AllowNullLiteral>] Stepper =
        inherit Vue
        /// Stepper goes to next step. 
        abstract nextStep: unit -> unit
        /// Stepper goes to previous step. 
        abstract previousStep: unit -> unit
        /// Stepper goes to “complete” state. 
        abstract finish: unit -> unit

    type [<AllowNullLiteral>] StepperContainer =
        inherit Stepper
        /// Resets progress
        abstract reset: unit -> unit

    type [<AllowNullLiteral>] tooltip =
        inherit IOpenCloseToggle

    type [<AllowNullLiteral>] IUploader =
        inherit Vue
        /// Start file(s) upload. 
        abstract upload: unit -> unit

    type [<AllowNullLiteral>] IAppVisibility =
        abstract isVisible: unit -> bool

    type [<AllowNullLiteral>] IAppFullscreen =
        /// Determining if website is in fullscreen mode 
        abstract isActive: unit -> bool
        /// Requesting fullscreen mode 
        abstract request: unit -> unit
        /// Exiting fullscreen mode 
        abstract exit: unit -> unit
        /// Toggle fullscreen mode 
        abstract toggle: unit -> unit

    type [<AllowNullLiteral>] ICookiesOptions =
        abstract expire: float option with get, set
        abstract path: string option with get, set
        abstract domain: string option with get, set
        abstract secure: bool option with get, set

    type [<AllowNullLiteral>] ICookies =
        abstract get: name: string -> string
        abstract all: unit -> ResizeArray<obj option>
        abstract has: name: string -> bool
        abstract set: name: string * value: string * ?options: ICookiesOptions -> unit
        abstract remove: name: string -> unit

    type [<AllowNullLiteral>] IEvents =
        /// Register for an event 
        abstract ``$on``: name: string * callback: Function -> unit
        /// Removing callback for an event 
        abstract ``$off``: name: string -> unit
        /// Registering a Callback to Be Run Only Once 
        abstract ``$once``: name: string * callback: Function -> unit
        /// Triggering an event 
        abstract ``$emit``: name: string * payload: obj option -> unit

    type [<AllowNullLiteral>] IUtils =
        abstract openUrl: url: string -> unit
        abstract debounce: fn: Function * milliseconds_to_wait: float * immediate: bool -> Function
        abstract throttle: fn: Function * milliseconds_to_wait: float -> Function
        abstract extend: deepCopyOrTarget: U2<bool, 'T> * target: obj * [<ParamArray>] ``object``: ResizeArray<Object> -> 'T
        abstract uid: unit -> string
        abstract animate: IUtilsAnimate with get, set
        abstract colors: IUtilsColors with get, set
        abstract format: IUtilsFormat with get, set
        abstract dom: IUtilsDom with get, set
        abstract ``event``: IUtilsEvent with get, set
        abstract filter: terms: string * options: IUtilsFilterOptions -> ResizeArray<obj>

    type [<AllowNullLiteral>] IUtilsFilterOptions =
        abstract field: string with get, set
        abstract list: ResizeArray<obj> with get, set

    type [<AllowNullLiteral>] IUtilsAnimate =
        abstract start: option: IUtilsAnimateOptions -> string
        abstract stop: idOrName: string -> unit

    type [<AllowNullLiteral>] IUtilsAnimateOptions =
        abstract name: string option with get, set
        abstract finalPos: float with get, set
        abstract pos: float with get, set
        abstract factor: float with get, set
        abstract ``done``: (float -> unit) with get, set
        abstract apply: (float -> unit) with get, set
        abstract treshhold: float with get, set

    type [<AllowNullLiteral>] IUtilsColors =
        abstract rgbToHex: red: float * green: float * blue: float -> string
        abstract hexToRgb: hex: string -> ResizeArray<float>

    type [<AllowNullLiteral>] IUtilsFormat =
        abstract humanStorageSize: size: float -> string

    type [<AllowNullLiteral>] IUtilsDom =
        abstract offset: el: HTMLElement -> obj
        abstract style: el: HTMLElement * property: string -> string
        abstract height: el: HTMLElement -> float
        abstract width: el: HTMLElement -> float
        abstract css: el: HTMLElement * css: obj -> unit
        abstract viewport: unit -> obj
        abstract ready: fn: Function -> unit
        abstract getScrollTarget: el: HTMLElement -> HTMLElement
        abstract getScrollPosition: scrollTarget: HTMLElement -> float
        abstract setScrollPosition: scrollTarget: HTMLElement * offset: float * duration: float -> unit
        abstract cssTransform: ``val``: string -> obj

    type [<AllowNullLiteral>] IUtilsEvent =
        abstract rightClick: e: MouseEvent -> bool
        abstract position: e: U2<MouseEvent, TouchEvent> -> obj
        abstract targetElement: e: U2<MouseEvent, TouchEvent> -> HTMLElement

    type [<AllowNullLiteral>] IWebStorage =
        abstract set: key: string * value: obj option -> unit
        abstract get: IWebStorageGet with get, set
        abstract remove: key: string -> unit
        abstract clear: unit -> unit
        abstract isEmpty: unit -> bool
        abstract has: key: string -> bool

    type [<AllowNullLiteral>] IWebStorageGet =
        abstract item: key: string -> obj option
        abstract all: unit -> obj
        abstract length: unit -> float
        abstract index: index: float -> obj option

    type [<AllowNullLiteral>] IPlateform =
        abstract is: obj with get, set
        abstract has: obj with get, set
        abstract within: obj with get, set

module Quasar_framework =

    type [<AllowNullLiteral>] IExports =
        abstract version: string
        abstract install: unit -> PluginFunction<obj>
        abstract start: callback: Function -> unit
        abstract theme: string
