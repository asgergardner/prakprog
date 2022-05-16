all:plot_fit_C.png
	make plot_fit_C.png

plot_fit_C.png:out.txt plot_fit_C.gpi
	pyxplot plot_fit_C.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs leastsq.dll matrix.dll vector.dll
	mcs -t:exe -r:leastsq.dll -r:matrix.dll -r:vector.dll $<

leastsq.dll:leastsq.cs lineq.dll matrix.dll vector.dll
	mcs -t:library -r:lineq.dll -r:matrix.dll -r:vector.dll $<

lineq.dll:lineq.cs matrix.dll vector.dll
	mcs -t:library -r:matrix.dll -r:vector.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll

