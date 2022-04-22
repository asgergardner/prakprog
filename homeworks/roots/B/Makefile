all:out.txt conv.png
	make conv.png

conv.png:out.txt plot_conv.gpi
	pyxplot plot_conv.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs vector.dll matrix.dll roots.dll rk.dll
	mcs -t:exe -r:vector.dll -r:matrix.dll -r:roots.dll -r:rk.dll $<

roots.dll:roots.cs vector.dll matrix.dll lineq.dll 
	mcs -t:library -r:vector.dll -r:matrix.dll -r:lineq.dll $<

rk.dll:rk.cs vector.dll matrix.dll
	mcs -t:library -r:vector.dll -r:matrix.dll $<	

lineq.dll:lineq.cs vector.dll matrix.dll
	mcs -t:library -r:vector.dll -r:matrix.dll $<

matrix.dll:matrix.cs vector.dll
	mcs -t:library -r:vector.dll $<

vector.dll:vector.cs
	mcs -t:library $<

.PHONY:
clean:
	rm -f *.exe *.dll *.txt
