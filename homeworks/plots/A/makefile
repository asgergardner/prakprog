erf.pyxplot.png: erf.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Error Function' \n\
	set key left top \n\
	plot '$<' index 0 using 1:2 with lines title 'calculated',\ \n\
	'erf.tab.txt' with points pointtype 3 pointsize 0.5 title 'tabulated' \n\
	" | tee log.gpi | pyxplot 

erf.data.txt:main.exe
	mono $< > $@
	
main.exe:main.cs functions.dll
	mcs -target:exe -reference:functions.dll $<

functions.dll:functions.cs
	mcs -target:library $<

.PHONY:
clean:
	rm out.txt *.exe *.png *.gp *.gpi
