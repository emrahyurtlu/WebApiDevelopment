import axios from "axios";
import { useState } from "react";

function App() {
	const [categories, setCategories] = useState([]);

	const loadWeatherForecastCategory = () => {
		axios.get("http://localhost:5245/WeatherForecastCategory").then((result) => {
			console.log(result);
			if (result.status == 200) {
				setCategories(result.data);
			}
		});
	};

	const loadWeatherForecast = () => {
		axios.get("http://localhost:5245/WeatherForecast").then((result) => {
			console.log(result);
		});
	};

	const createWeatherForecast = () => {
		axios.post("http://localhost:5245/WeatherForecast").then((result) => {
			console.log(result);
		});
	};

	return (
		<>
			<div>
				<h1>Load Wheather Forecast Categories</h1>
				<button onClick={loadWeatherForecastCategory}>Load Categories</button>
				<br />
				<ul>{categories.length > 0 && categories.map((t) => <li key={t}>{t}</li>)}</ul>
			</div>

			<div>
				<h1>Load Wheather Forecasts</h1>
				<button onClick={loadWeatherForecast}>Load WheatherForecasts</button>
				<button onClick={createWeatherForecast}>Create WheatherForecasts</button>
			</div>
		</>
	);
}

export default App;
