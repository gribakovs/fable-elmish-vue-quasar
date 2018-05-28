module Global

type Page = About | Counter
let toHash = function About -> "#about" | Counter -> "#counter"
