import { CardStyleInterpolators } from '@react-navigation/stack';
import React, {useEffect, useState, useRef} from 'react';
import {SafeAreaView, View, FlatList, StyleSheet, Text, StatusBar, Image, Animated} from 'react-native';



const OneCookView = (props) => {
    const {cook, backAnimFunc}= props.route.params;
    const rotateAnimDetail = useRef(new Animated.Value(0)).current;

    const rotate = () => {
      Animated.timing(rotateAnimDetail, {
          toValue: 1,
          duration: 700,
          useNativeDriver: true
        }).start();
    }
    useEffect(() =>{
      rotate();
      return () => {
        backAnimFunc();
      }
    }, []);

    return (
            <Animated.View style={{ margin:20,
              transform:[
                {
                    rotateY: rotateAnimDetail.interpolate({
                        inputRange: [0, 1],
                        outputRange: ["90deg", "0deg"],
                    }),
                },
            ],
            }}>
                <Text>Name: <Text style={styles.innerText}> {cook.name}</Text></Text>
                <Text>Surname: <Text style={styles.innerText}>{cook.surname}</Text></Text>
                <Text>Email: <Text style={styles.innerText}>{cook.email}</Text></Text>
                <Text>Verified: <Text style={styles.innerText}>{cook.verified.toString()}</Text></Text>
                <Text>Admin: <Text style={styles.innerText}>{cook.admin.toString()}</Text></Text>
            </Animated.View>
    )

}
const styles = StyleSheet.create({
    container: {
      flex: 1,
      marginTop: StatusBar.currentHeight || 0,
      marginLeft: 20,
    },
    item: {
      backgroundColor: '#00bfff',
      padding: 20,
      marginVertical: 8,
      marginHorizontal: 16,
    },
    title: {
      fontSize: 24,
    },
    flag: {
      height: 64,
      width: 64
    },
    innerText: {
      fontWeight: 'bold'
    }
});
  
export default OneCookView;