all: out.txt
	cat out.txt

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs vec.dll
	mcs -target:exe -out:main.exe -reference:vec.dll main.cs

vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	rm main.exe vec.dll 
