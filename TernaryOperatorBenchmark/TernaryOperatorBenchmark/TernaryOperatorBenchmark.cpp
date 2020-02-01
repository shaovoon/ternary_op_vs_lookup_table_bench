#include <vector>
#include <iostream>
#include <iomanip>
#include <string>
#include <numeric>
#include <chrono>
#include <algorithm>
#include <random>

class timer
{
public:
	timer() = default;
	void start(const std::string& text_)
	{
		text = text_;
		begin = std::chrono::high_resolution_clock::now();
	}
	void stop(int64_t result)
	{
		auto end = std::chrono::high_resolution_clock::now();
		auto dur = end - begin;
		auto ms = std::chrono::duration_cast<std::chrono::milliseconds>(dur).count();
		std::cout << std::setw(19) << text << ":" << std::setw(5) << ms << "ms" << ", result:" << result << std::endl;
	}
	void stop(double result)
	{
		auto end = std::chrono::high_resolution_clock::now();
		auto dur = end - begin;
		auto ms = std::chrono::duration_cast<std::chrono::milliseconds>(dur).count();
		std::cout << std::setw(19) << text << ":" << std::setw(5) << ms << "ms" << ", result:" << result << std::endl;
	}

private:
	std::string text;
	std::chrono::high_resolution_clock::time_point begin;
};

int64_t IntTernaryOp(bool value)
{
	return value ? 3 : 4;
}

int64_t IntArrayOp(bool value)
{
	static const int64_t arr[2] = { 3, 4 };
	return arr[value];
}

double FloatTernaryOp(bool value)
{
	return value ? 3.0f : 4.0f;
}

double FloatArrayOp(bool value)
{
	static const double arr[2] = { 3.0f, 4.0f };
	return arr[value];
}

int main()
{
	const size_t MAX_LOOP = 1000000000;
	
	int64_t sum = 0;
	double sum_f = 0;

	timer stopwatch;

	stopwatch.start("IntTernaryOp");
	sum = 0;
	for (size_t k = 0; k < MAX_LOOP; ++k)
	{
		sum += IntTernaryOp(k % 2);
	}
	stopwatch.stop(sum);

	stopwatch.start("IntArrayOp");
	sum = 0;
	for (size_t k = 0; k < MAX_LOOP; ++k)
	{
		sum += IntArrayOp(k % 2);
	}
	stopwatch.stop(sum);

	stopwatch.start("FloatTernaryOp");
	sum_f = 0;
	for (size_t k = 0; k < MAX_LOOP; ++k)
	{
		sum_f += FloatTernaryOp(k % 2);
	}
	stopwatch.stop(sum_f);

	stopwatch.start("FloatArrayOp");
	sum_f = 0;
	for (size_t k = 0; k < MAX_LOOP; ++k)
	{
		sum_f += FloatArrayOp(k % 2);
	}
	stopwatch.stop(sum_f);

    std::cout << "Done!\n";
	
	return 0;
}
