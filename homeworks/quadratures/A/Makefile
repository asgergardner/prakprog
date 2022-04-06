all:out.txt ploterf.png
	cat $<

ploterf.png:ploterf.txt erftab.txt ploterf.gpi
	pyxplot ploterf.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs integrator.dll
	mcs -t:exe -r:integrator.dll $<

integrator.dll:integrator.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.png
