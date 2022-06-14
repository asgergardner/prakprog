
cgamma.pyxplot.png: cgamma.data.txt Makefile
	echo "\
        set terminal png \n\
        set output '$@' \n\
	set xlabel 'Im(x)' \n\
        set ylabel 'Re(x)' \n\
        set title 'Complex Gamma Function' \n\
        set key below \n\
	set grid \n\
	set size 8 square \n\
	plot 3d [-5:5][-5:5][0:25] '$<' index 0 using 2:1:3 with surface col black fillcol red title 'abs(x)' \n\
        " | tee log.gpi | pyxplot

cgamma.data.txt:main.exe
	mono $< > $@
	
main.exe:main.cs functions.dll cmath.dll complex.dll
	mcs -target:exe -reference:functions.dll,cmath.dll,complex.dll $<

functions.dll:functions.cs cmath.dll complex.dll
	mcs -target:library -reference:cmath.dll,complex.dll $<

cmath.dll: cmath.cs complex.dll
	mcs -target:library -reference:complex.dll $< 

complex.dll:complex.cs
	mcs -target:library $<

.PHONY:
clean:
	rm out.txt *.exe *.png *.gp *.gpi
