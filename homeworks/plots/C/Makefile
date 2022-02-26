CMATHDIR = /mnt/c/Users/asger/prakprog/complex

cgamma.pyxplot.png: cgamma.data.txt Makefile
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set title 'Complex Gamma Function' \n\
        set key left top \n\
        plot [0:5][-20:20] '$<' index 0 using 1:3 with lines title 'calculated',\ \n\
        'gamma.tab.txt' with points pointtype 3 pointsize 0.5 title 'tabulated' \n\
        " | tee log.gpi | pyxplot

cgamma.data.txt:main.exe
	mono $< > $@
	
main.exe:main.cs functions.dll
	mcs -target:exe -reference:functions.dll $<

functions.dll:functions.cs cmath.dll
	mcs -target:library -reference:cmath.dll $<

cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll

.PHONY:
clean:
	rm out.txt *.exe *.png *.gp *.gpi
