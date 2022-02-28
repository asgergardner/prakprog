CMATHDIR = /mnt/c/Users/asger/prakprog/complex

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
	
main.exe:main.cs functions.dll cmath.dll
	mcs -target:exe -reference:functions.dll -reference:cmath.dll $<

functions.dll:functions.cs cmath.dll
	mcs -target:library -reference:cmath.dll $<

cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll

.PHONY:
clean:
	rm out.txt *.exe *.png *.gp *.gpi
