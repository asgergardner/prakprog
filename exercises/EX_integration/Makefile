all:out.txt erfplot.png
	cat out.txt

erfplot.png:out.txt
	echo "\
        set terminal png \n\
        set output '$@' \n\
        set xlabel 'x' \n\
        set ylabel 'y' \n\
        set title 'Integral representation of error function' \n\
        set key left top \n\
	set grid \n\
        plot '$<' index 1 using 1:2 with lines title 'erf(z)' \n\
        " | tee log.gpi | pyxplot

out.txt:main.exe
	mono $< > $@

main.exe:main.cs integrate.dll 
	mcs -target:exe -reference:integrate.dll $<

integrate.dll:integrate.cs
	mcs -target:library $<

.PHONY:
clean:
	rm *.txt *.dll *.exe
