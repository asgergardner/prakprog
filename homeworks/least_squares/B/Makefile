all:plot_fit_B.png fitlog.txt
	make plot_fit_B.png
	cat fitlog.txt

plot_fit_B.png:out.txt plot_fit_B.gpi
	pyxplot plot_fit_B.gpi

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

