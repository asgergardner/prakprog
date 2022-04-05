all:
	make ode.png

ode.png:out.txt plot_ode.gpi
	pyxplot plot_ode.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs rk.dll vector.dll
	mcs -t:exe -r:rk.dll -r:vector.dll $< 

rk.dll:rk.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll
