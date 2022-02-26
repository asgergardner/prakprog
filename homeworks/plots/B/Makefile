all:
	make gamma.pyxplot.png lngamma.pyxplot.png

lngamma.pyxplot.png: gamma.data.txt Makefile
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set title 'ln(Gamma) Function' \n\
        set key left top \n\
        plot [0:5][-20:20] '$<' index 0 using 1:3 with lines title 'calculated',\ \n\
        'gamma.tab.txt' with points pointtype 3 pointsize 0.5 title 'tabulated' \n\
        " | tee log.gpi | pyxplot

gamma.pyxplot.png: gamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Gamma Function' \n\
	set key left top \n\
	plot [-5:5][-20:20] '$<' index 0 using 1:2 with lines title 'calculated',\ \n\
	'gamma.tab.txt' with points pointtype 3 pointsize 0.5 title 'tabulated' \n\
	" | tee log.gpi | pyxplot 

gamma.data.txt:main.exe
	mono $< > $@
	
main.exe:main.cs functions.dll
	mcs -target:exe -reference:functions.dll $<

functions.dll:functions.cs
	mcs -target:library $<

.PHONY:
clean:
	rm out.txt *.exe *.png *.gp *.gpi
