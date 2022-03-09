test_linterp.png:out.txt test_linterp.gpi
	pyxplot test_linterp.gpi

out.txt:main.exe
	mono $< > $@

main.exe:main.cs interpolator.dll
	mcs -target:exe -reference:interpolator.dll $<

interpolator.dll:interpolator.cs
	mcs -target:library $<

.PHONY:
clean:
	rm -f *.exe *.txt *.dll *.png
