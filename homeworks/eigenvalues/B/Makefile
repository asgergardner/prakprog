all:out.txt
	make rconvergence.png nconvergence.png radialwf.png

rconvergence.png:r_convergence.txt plot_rconvergence.gpi
	pyxplot plot_rconvergence.gpi

nconvergence.png:n_convergence.txt plot_nconvergence.gpi
	pyxplot plot_nconvergence.gpi

r_convergence.txt:out.txt

n_convergence.txt:out.txt

radialwf.png:out.txt plot_radialwf.gpi
	pyxplot plot_radialwf.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs matrix.dll vector.dll evd.dll
	mcs -t:exe -r:matrix.dll -r:vector.dll -r:evd.dll $<

evd.dll:evd.cs matrix.dll vector.dll
	mcs -t:library -r:matrix.dll -r:vector.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll
