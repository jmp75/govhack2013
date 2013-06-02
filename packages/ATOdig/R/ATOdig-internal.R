#' find the categories in the table extracted from the ATO excel file
#'
#' find the categories in the table extracted from the ATO excel file
#'
#' @param str_mat the character matrix 
#' @return nothing is returned by this function
findCategories <- function(str_mat) {
  d <- str_mat[,1]
  d[which(d != "")]
}

#' find the categories in the table extracted from the ATO excel file
#'
#' find the categories in the table extracted from the ATO excel file
#'
#' @param d the character matrix 
#' @export
#' @return a list of data frames, with the series for ATO data.
extractSeries <- function(d) {
  # FIXME: a LOT of assumptions are made about the spreadsheet data in here...
  catIndex <- which(d[,1] != "")
  lblIndex <- which(d[,2] != "")
  # Well, assumptions have to be made given the unstructured data:
  lblsPerCat <- length(lblIndex) / length(catIndex)

  getDataCategory <- function(i) {
    rows <- catIndex[i]+1:lblsPerCat
    units <- d[rows,3]
    series <- d[rows,4:ncol(d)]
    series[series=="n.a."] <- NA
    series.df <- as.data.frame(t(matrix(as.numeric(series), nrow=length(rows))))
    names(series.df) <- d[rows,2]
    attr(series.df, 'units') <- units
    series.df
  }
  
  result <- lapply(1:length(catIndex), FUN=getDataCategory)
  names(result) <- d[catIndex,1]
  result
}

