ATO.Dig - govhack2013
===========

Purpose
---------------
I have 5 hours to figure out something submittable... Let's see.
* That won't be about quantity, that is for sure.
* I want to graph the available Excel ATO data in R in a manner that is scalable and further automatable, given time.

Design
---------------

* Access to the Australian Tax Office file (e.g. http://opendata.linkdigital.com.au/dataset/taxation-statistics-2010-11/resource/d85f8d81-b011-4329-9db3-7d3b09761a14) is done reusing the open source project https://exceldatareader.codeplex.com. Brilliant - just found out about it
* Conversion from .NET code to R data reusing another project I authored: https://r2clr.codeplex.com/
* An R package to process the raw, relatively unstructured ATO data extracted from the Excel spreadsheed
* Use ggplot2, googleVis, rCharts, shiny, etc. in R to visualise/analyse. Won't have time to do it...

Sample usage
---------------

As previously said, not about quantity. That works:

```r
library(rClr)
setRDotNet(TRUE)
clrLoadAssembly('c:/src/ATO.Dig/ATO.Dig.Data/bin/Debug/ATO.Dig.Data.dll')
d <- clrCallStatic('ATO.Dig.Data.AtoExcelAccess', 'GetSpreadsheet', as.integer(2), "C:/tmp/2010-11-datasets/2010-11 datasets/cor00345977_2011CGT1.xls")
library(ATOdig)
capitalGain <- ATOdig::extractSeries(d)
names(capitalGain) # categories
plot(capitalGain[[1]])
```

Further work, ideas post GovHack
---------------

* Unleash new ways for the masses to make their own judgment on real/effective tax policies? Who knows.
* Demo at the useR2013 conference!
