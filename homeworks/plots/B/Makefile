erf.pyxplot.png: erf.data.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	plot '$<' index 0 using 1:2 with lines title 'error function' \n\
	" | tee log.gpi | pyxplot 

erf.data.txt:main.exe
	mono $< > $@
	
main.exe:main.cs functions.dll
	mcs -target:exe -reference:functions.dll $<

functions.dll:functions.cs
	mcs -target:library $<

.PHONY:
clean:
	rm *.exe *.txt *.png
