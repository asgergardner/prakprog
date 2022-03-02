all:ms.pdf

ms.pdf:ms.tex explot.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<	# if multiple references
#	bibtex $<

explot.pdf:exp.data.txt
	echo '\
	set terminal pdf \n\
	set output "$@" \n\
	set grid \n\
	plot "$<" using 1:2 with lines title "Continued fraction",\ \n\
	"$<" using 1:3 with points title "System.Math.Exp" \n\
	' | pyxplot 
		

exp.data.txt:main.exe
	mono $< > $@

main.exe:main.cs
	mcs -t:exe $<


.PHONY:
clean:
	rm -f *.pdf *.log *.aux *.txt *.exe

