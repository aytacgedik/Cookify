import { ThemeProvider } from '@react-navigation/native';
import { HeaderStyleInterpolators } from '@react-navigation/stack';
import React, { useEffect, useState, useRef } from 'react';
import { SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated, LogBox, ScrollView} from 'react-native';
import {TextInput, TouchableOpacity} from 'react-native-gesture-handler';
import { Value } from 'react-native-reanimated';
import { withSafeAreaInsets } from 'react-native-safe-area-context';

LogBox.ignoreLogs([
    'Non-serializable values were found in the navigation state',
  ]);
const renderListItem = (item, navigation, rotate, fadeOut, backAnimFunc) => (
    <View style={styles.item}>
        <TouchableOpacity onPress={()=> { fadeOut(); rotate(); setTimeout(()=>{navigation.push("Recipe", {recipe: item,backAnimFunc: backAnimFunc});}, 700) }}>
            <Text style={styles.title}>{item.name}</Text>
        </TouchableOpacity>
    </View>

);

const RecipesList = ( {navigation} ) => {
    const [isLoading, setLoading] = useState(true);
    const [recipes, setRecipes] = useState([]);
    const fadeAnim = useRef(new Animated.Value(0)).current;
    const rotateAnim = useRef(new Animated.Value(0)).current;

    const fadeIn = () => {
        Animated.timing(fadeAnim, {
          toValue: 1,
          duration: 700,
          useNativeDriver: true
        }).start();
    }

    const fadeOut = () => {
        Animated.timing(fadeAnim, {
            toValue: 0,
            duration: 700,
            useNativeDriver: true  
        }).start();
    }

    const rotate = () => {
        Animated.timing(rotateAnim, {
            toValue: 1,
            duration: 700,
            useNativeDriver: true
          }).start();
    }
    const rotateBack = () =>{
        Animated.timing(rotateAnim, {
            toValue: 0,
            duration: 700,
            useNativeDriver: true
        }).start();
    }
    const backAnimFunc = () => {
        fadeIn();
        rotateBack();
    }

    const fetchData = () => {
        setLoading(true);
        const url = `https://cookifyv2.azurewebsites.net/api/recipes`;
        // Strange backend (1)
        // original: `https://cookify.azurewebsites.net/api/recipes`
        // try: `https://se2-h-backend.herokuapp.com/api/recipes`
        fetch(url)
        .then((response) => response.json())
        .then((json) => setRecipes(json))
        .then(() => {fadeIn();})
        .catch((error) => console.error(error))
        .finally(() => setLoading(false));
    }
    
    useEffect(() =>{
        fetchData();
    }, []);

    return (
        <SafeAreaView style={styles.container}>     
            <ScrollView>
                <View style={styles.createItem}>
                <TouchableOpacity onPress={()=> { navigation.push("CreateRecipe", {}) }}>
                    <Text style={styles.title}>Create Recipe</Text>
                </TouchableOpacity>
                </View>
                
                {isLoading ? <Text style={styles.textLabel}>Loading...</Text> :
                <Animated.View style={{opacity: fadeAnim,
                transform:[
                    {
                        rotateY: rotateAnim.interpolate({
                            inputRange: [0, 1],
                            outputRange: ["0deg", "180deg"],
                        }),
                    },
                ],
                }}>
                    <FlatList
                        data={recipes.length > 0 ? recipes.slice(0, recipes.length) : []}
                        renderItem={({item}) => renderListItem(item, navigation, rotate, fadeOut, backAnimFunc)}
                        keyExtractor={item => JSON.stringify(item.id)}
                        onRefresh={() => fetchData()}
                        refreshing={isLoading}
                    />
                </Animated.View>}
            </ScrollView>
        </SafeAreaView>
    );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: (StatusBar.currentHeight || 0),
  },
  item: {
    backgroundColor: '#00bfff',
    padding: 20,
    marginVertical: 8,
    marginHorizontal: 16,
  },
  createItem: {
    backgroundColor: '#00ff00',
    padding: 20,
    marginVertical: 8,
    marginHorizontal: 16
  },
  title: {
    fontSize: 24,
  },
  flag: {
    height: 64,
    width: 64
  },
  textInput: {
    fontSize: 15,
    color: 'green',
    borderWidth: 1,
    borderColor: 'black',
    margin: 15,
    paddingLeft: 10
  },
  textLabel: {
      marginLeft: 15,
      marginBottom: 5
  }
});

export default RecipesList;