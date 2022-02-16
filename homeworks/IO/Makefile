$(info Running all 3 files simultaneously:)

all : out_stdin.txt out_cmdline.txt out_fileio.txt
	cat out_stdin.txt out_cmdline.txt out_fileio.txt

out_stdin.txt : stdin.exe
	echo 1 2 3 4 5 | mono $< > $@

out_cmdline.txt : cmdline.exe
	mono $< 1 2 3 4 5 > $@

out_fileio.txt : fileio.exe input.txt
	mono $< -input:input.txt -output:$@

stdin.exe : stdin.cs
	mcs -target:exe stdin.cs

cmdline.exe : cmdline.cs
	mcs -target:exe cmdline.cs

fileio.exe : fileio.cs
	mcs -target:exe fileio.cs

.PHONY: clean
clean: 
	rm *.exe out*
